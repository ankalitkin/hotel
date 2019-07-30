using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Entities;

namespace Hotel.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly HotelContext _context;

        public TransactionsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }


        // GET: api/Transactions/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTransaction(int id, [FromBody]Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction([FromBody]Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Transaction>> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }

        // GET HISTORY: api/Transactions/myHistory
        [HttpGet("myHistory")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetMyHistory()
        {
            int id = 1; // TODO: когда будет регистрация
            return await _context.Transactions.AsNoTracking().Where(t => t.UserId == id).ToListAsync();
        }

        public class FinancialInfo
        {
            public DateTime dateTime;
            public int Sum;

            public FinancialInfo(DateTime dateTime, int Sum)
            {
                this.dateTime = dateTime;
                this.Sum = Sum;
            }
        }

        // GET INFO: api/transactions/FinancialInformation?start=07%2F13%2F2019&end=07%2F16%2F2019
        [HttpGet("FinancialInformation")]
        public async Task<ActionResult<IEnumerable<FinancialInfo>>> GetFinancialInformation(DateTime? start, DateTime? end)
        {
            if (start == null)
                start = DateTime.MinValue;
            if (end == null)
                end = DateTime.Now;
            var result = _context.Transactions.AsNoTracking()
            .Where(t => t.CheckInTime >= start && t.CheckInTime <= end)
            .GroupBy(t => t.CheckInTime.Date)
            .Select(g => new FinancialInfo(g.Key, g.Sum(t => t.Cost)));

            return await result.ToListAsync();
        }

        //TODO: получение не только пользователя, но и номер комнаты и т.д (и по id транзакции)
        // GET: api/Transactions/User/5
        [HttpGet("User/{id:int}")]
        public async Task<ActionResult<User>> GetExpandData(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == user.RoleId);
            user.Role = role;

            return user;
        }

        // GET: api/Transactions/Filter?start=07%2F13%2F2019&end=07%2F16%2F2019&type=all&id=123456789012
        [HttpGet("Info")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetInfo(DateTime? start, DateTime? end, string type, string id)
        {
            bool isPaid = false, isCanceled = false, all = false;

            if (type == "all")
                all = true;
            else if (type == "isPaid")
                isPaid = true;
            else if (type == "isCanceled")
                isCanceled = true;

            int userId = -1;
            if (id != null)
            {
                var user = await _context.Users.Where(u => u.ClientID == id).FirstOrDefaultAsync();
                userId = user != null ? user.UserId : userId;
            }

            var list = await _context.Transactions.AsNoTracking()
                .Where(t => (id == null || userId < 0) || t.UserId == userId)
                .Where(t => start == null || t.CheckInTime >= start)
                .Where(t => end == null || t.CheckOutTime <= end)
                .Where(t => all || t.IsPaid == isPaid && t.IsCanceled == isCanceled)
                .ToListAsync();

            return list;
        }

        // GET: api/Transactions/FreeRooms?start=07%2F13%2F2019&end=07%2F16%2F2019&type=3
        [HttpGet("FreeRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetFreeRooms(DateTime start, DateTime end, int type)
        {
            var list = from room in _context.Rooms
                       join trans in _context.Transactions
                       on room.RoomId equals trans.RoomId
                       where trans.CheckInTime <= start && trans.CheckOutTime <= start
                       || trans.CheckInTime >= end && trans.CheckOutTime >= end
                       select room;


            return await list.ToListAsync();
        }

    }
}
