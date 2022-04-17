using Microsoft.EntityFrameworkCore;

namespace Cw1_w1867890_Category
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
    }
}
