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

            transaction.Cost = GetRoomCost(transaction.RoomId);

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
            if (transaction.Cost <= 0)
                transaction.Cost = GetRoomCost(transaction.RoomId);

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

        // GET INFO: api/transactions/FinancialInformation?start=2019-07-13&end=2019-07-16
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

        public class ExpandData
        {
            public ExpandData(User user, Room room, int transactionId)
            {
                TransactionId = transactionId;

                UserName = user.FirstName + ' ' + user.LastName;
                BirthDate = user.BirthDate;
                Email = user.Email;
                Phone = user.Phone;
                ClientID = user.ClientId;

                RoomName = room.Name;
                Floor = room.Floor;
                RoomTypeId = room.RoomTypeId;
                NumberOfSeats = room.NumberOfSeats;
                HasMiniBar = room.HasMiniBar;
            }

            public int TransactionId;

            public string UserName;
            public DateTime BirthDate;
            public string Email;
            public string Phone;
            public string ClientID;

            public string RoomName;
            public string Floor;
            public int RoomTypeId;
            public int NumberOfSeats;
            public bool HasMiniBar;

        }

        // GET: api/Transactions/ExpandData/3
        [HttpGet("ExpandData/{id:int}")]
        public async Task<ActionResult<ExpandData>> GetExpandData(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(transaction.UserId);
            var room = await _context.Rooms.FindAsync(transaction.RoomId);

            if (user == null || room == null)
            {
                return NotFound();
            }
            // чтобы визуалка не ругалась :)
            Role role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == user.RoleId);
            user.Role = role;

            return new ExpandData(user, room, transaction.TransactionId);
        }

        // GET: api/Transactions/Info?start=2019-07-13&end=2019-07-16&type=all&id=123456789012
        [HttpGet("Info")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetInfo(DateTime? start, DateTime? end, string type, string id)
        {
            // TODO: если запрос от пользователя, то выдать только его транзакции(т.е. присвоить нужное значение id)

            bool isPaid = false, isCanceled = false, all = false, isReadyComeIn = false, isReadyComeOut = false;

            // P.S. мб лучше было бы сделать множественный выбор
            switch (type)
            {
                case "all":
                    {
                        all = true;
                        break;
                    }
                case "isPaid":
                    {
                        isPaid = true;
                        break;
                    }
                case "isCanceled":
                    {
                        isCanceled = true;
                        break;
                    }
                case "isReadyComeIn":
                    {
                        isReadyComeIn = true;
                        break;
                    }
                case "isReadyComeOut":
                    {
                        isReadyComeOut = true;
                        break;
                    }
            }

            int userId = -1;
            if (id != null)
            {
                var user = await _context.Users.Where(u => u.ClientId == id).FirstOrDefaultAsync();
                userId = user != null ? user.UserId : userId;

                if (userId == -1)
                {
                    return BadRequest();
                }
            }


            var list = await _context.Transactions.AsNoTracking()
                .Where(t => (id == null) || t.UserId == userId)
                .Where(t => start == null || t.CheckInTime >= start)
                .Where(t => end == null || t.CheckOutTime <= end)
                .Where(t => all ||
                t.IsPaid == isPaid && t.IsCanceled == isCanceled
                && (!isReadyComeIn || t.CheckInTime == DateTime.Today)
                && (!isReadyComeOut || t.CheckOutTime == DateTime.Today))
                .ToListAsync();

            return list;
        }

        // GET: api/Transactions/FreeRooms?start=2019-07-13&end=2019-07-16&type=3&seats=2&minibar=true
        [HttpGet("FreeRooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetFreeRooms(DateTime start, DateTime end, int? type, int? seats, bool? minibar)
        {
            var list = from room in _context.Rooms
                       where type == null || room.RoomTypeId == type &&
                       seats == null || room.NumberOfSeats == seats &&
                       minibar == null || room.HasMiniBar == minibar
                       join trans in _context.Transactions
                       on room.RoomId equals trans.RoomId into p
                       from t in p.DefaultIfEmpty()
                       where t == null || (t.CheckInTime <= start && t.CheckOutTime <= start
                        || t.CheckInTime >= end && t.CheckOutTime >= end || t.IsCanceled)
                       select room;

            return await list.ToListAsync();
        }

        public class RoomAndTransaction
        {
            public Room room;
            public Transaction transaction;
        }
        // POST: api/Transactions/RoomId
        [HttpPost("RoomId")]
        public async Task<ActionResult<int>> GetFreeRoomId([FromBody]RoomAndTransaction roomAndTransaction)
        {
            Room room = roomAndTransaction.room;
            Transaction transaction = roomAndTransaction.transaction;

            var RoomQuery = from r in _context.Rooms
                         where r.RoomTypeId == room.RoomTypeId &&
                         r.NumberOfSeats == room.NumberOfSeats &&
                         r.HasMiniBar == room.HasMiniBar
                         join tr in _context.Transactions
                         on r.RoomId equals tr.RoomId into p
                         from trans in p.DefaultIfEmpty()
                         where trans == null || ((trans.CheckInTime <= transaction.CheckInTime &&
                         trans.CheckOutTime <= transaction.CheckOutTime
                         || trans.CheckInTime >= transaction.CheckInTime &&
                            trans.CheckOutTime >= transaction.CheckOutTime)
                         || trans.IsCanceled
                         || trans.TransactionId == transaction.TransactionId)
                         select r.RoomId;

            var list = await RoomQuery.ToListAsync(); 
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
            var RoomId =  await RoomQuery.FirstOrDefaultAsync();
            return RoomId;
        }

        public int GetRoomCost(int roomId)
        {
            var room = _context.Rooms.Find(roomId);

            if (room == null)
            {
                return 0;
            }

            var cost = _context.RoomCosts
                .Where(rc => rc.CategoryId == room.RoomTypeId)
                .Where(rc => rc.NumberOfSeats == room.NumberOfSeats)
                .Where(rc => rc.HasMiniBar == room.HasMiniBar)
                .Select(rc => rc.Cost)
                .FirstOrDefault();

            if (cost <= 0) // ну кто знает :)
                cost = 1400;

            return cost;
        }
    }
}
