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
            /*
            var list = await _context.Transactions.AsNoTracking().ToListAsync();
            // пробовал по-другому, с Join, но что-то не вышло(
            foreach(Transaction t in list)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == t.UserId);
                Role role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == user.RoleId);
                user.Role = role;
                t.User = user;
            }
            return list;
            */
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

        // GET HISTORY: api/Transactions/History/3?isPaid=false
        [HttpGet("History/{id:int}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetHistory(int id, bool IsOnlyPaid = false) // IsOnlyPaid == true  только оплаченные(т.е. только история проживаия, без бронироваия)
        {
            return await _context.Transactions.AsNoTracking().Where(t => t.UserId == id && (IsOnlyPaid ? t.IsPaid : true)).ToListAsync();
        }

        // GET INFO: api/Transactions/Info?date=07%2F13%2F2019
        [HttpGet("Info")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetInfo(DateTime? date)
        {
            if (date == null)
                date = DateTime.Today;

            return await _context.Transactions.AsNoTracking().Where(t => t.CheckOutTime >= date && !t.IsCanceled).ToListAsync();
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
        public async Task<ActionResult<IEnumerable<FinancialInfo>>> GetFinancialInformation(DateTime start, DateTime? end)
        {
            if (end == null)
                end = DateTime.Now;
            var result = _context.Transactions.AsNoTracking()
            .Where(t => t.CheckInTime >= start && t.CheckInTime <= end)
            .GroupBy(t => t.CheckInTime.Date)
            .Select(g => new FinancialInfo(g.Key, g.Sum(t => t.Cost)));

            return await result.ToListAsync();
        }

        // ПЕРЕМЕСТИТЬ В USER CONTROLLER
        // GET: api/Transactions/User/5
        [HttpGet("User/{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
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

    }
}
