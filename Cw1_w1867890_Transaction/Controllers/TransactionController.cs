using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Transaction>> SearchAll()
        {
            return transactionDbContext.Transactions.ToList();

        }

        [HttpGet("transaction/search/{id}")]
        public ActionResult<Transaction> SearchById(int id)
        {
            var tran = transactionDbContext.Transactions.Find(id);

            if (tran == null)
            {
                return NotFound();
            }

            return tran;
        }

        [HttpPost("transaction/create")]
        public IActionResult Create(Transaction transaction)
        {
            Transaction t = new Transaction();
            t.TranCatId = transaction.TranCatId;
            t.TranDescription = transaction.TranDescription;
            t.TranDate = transaction.TranDate;
            t.TranRecurring = transaction.TranRecurring;
            t.TranAmount = Double.Parse(transaction.TranAmount.ToString());

            this.transactionDbContext.Transactions.Add(transaction);
            this.transactionDbContext.SaveChanges();

            return Accepted();
        }

        [HttpPut("transaction/update/{id}")]
        public IActionResult Update(int id, [FromBody] Transaction transaction)
        {
            var dbTransaction = this.transactionDbContext.Transactions
                .FirstOrDefault(s => s.TranId.Equals(id));

            dbTransaction.TranCatId = transaction.TranCatId;
            dbTransaction.TranDescription = transaction.TranDescription;
            dbTransaction.TranDate = transaction.TranDate;
            dbTransaction.TranRecurring = transaction.TranRecurring;
            dbTransaction.TranAmount = transaction.TranAmount;

            this.transactionDbContext.SaveChanges();

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
