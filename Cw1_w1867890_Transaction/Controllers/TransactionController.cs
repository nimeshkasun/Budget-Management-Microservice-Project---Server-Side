using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw1_w1867890_Transaction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private TransactionDbContext transactionDbContext;

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger, TransactionDbContext transactionDbContext)
        {
            _logger = logger;
            this.transactionDbContext = transactionDbContext;
        }

        [HttpGet]
        public String Get()
        {
            return "Transaction API Online";
        }

        [HttpGet("transaction/search/all")]
        public async Task<ActionResult<List<Transaction>>> SearchAll()
        {
            return await transactionDbContext.Transactions.ToListAsync();

        }        

        [HttpPost("transaction/create")]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            Transaction t = new Transaction();
            t.TranCatId = transaction.TranCatId;
            t.TranDescription = transaction.TranDescription;
            t.TranDate = transaction.TranDate;
            t.TranRecurring = transaction.TranRecurring;
            t.TranAmount = Double.Parse(transaction.TranAmount.ToString());

            this.transactionDbContext.Transactions.Add(transaction);
            await this.transactionDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpGet("transaction/search/{id}")]
        public async Task<ActionResult<Transaction>> SearchById(int id)
        {
            var tran = await transactionDbContext.Transactions.FindAsync(id);

            if (tran == null)
            {
                return NotFound();
            }

            return tran;
        }

        [HttpPut("transaction/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Transaction transaction)
        {
            var dbTransaction = await this.transactionDbContext.Transactions
                .FirstOrDefaultAsync(s => s.TranId.Equals(id));

            dbTransaction.TranCatId = transaction.TranCatId;
            dbTransaction.TranDescription = transaction.TranDescription;
            dbTransaction.TranDate = transaction.TranDate;
            dbTransaction.TranRecurring = transaction.TranRecurring;
            dbTransaction.TranAmount = transaction.TranAmount;

            await this.transactionDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpDelete("transaction/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = this.transactionDbContext.Transactions
                .FirstOrDefault(s => s.TranId.Equals(id));
            if (transaction == null)
                return BadRequest();
            this.transactionDbContext.Remove(transaction);
            this.transactionDbContext.SaveChanges();

            return Accepted();
        }
    }
}
