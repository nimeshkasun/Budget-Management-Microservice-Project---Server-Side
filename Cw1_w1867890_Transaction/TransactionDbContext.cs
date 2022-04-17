using Microsoft.EntityFrameworkCore;

namespace Cw1_w1867890_Transaction
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
