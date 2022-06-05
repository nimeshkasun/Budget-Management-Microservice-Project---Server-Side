using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw1_w1867890_Category.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private CategoryDbContext categoryDbContext;

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, CategoryDbContext categoryDbContext)
        {
            _logger = logger;
            this.categoryDbContext = categoryDbContext;
        }

        [HttpGet]
        public String Get()
        {
            return "Category API Online";
        }

        [HttpGet("category/search/all")]
        public async Task<ActionResult<List<Category>>> SearchAll()
        {
            return await categoryDbContext.Categories.OrderByDescending(i => i.CatId).ToListAsync();
            
        }

        [HttpPost("category/create")]
        public async Task<IActionResult> Create(Category category)
        {
            Category c = new Category();
            c.CatName = category.CatName;
            c.CatType = category.CatType;
            c.CatBudget = Double.Parse(category.CatBudget.ToString());

            this.categoryDbContext.Categories.Add(category);
            await this.categoryDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpGet("category/search/{id}")]
        public async Task<ActionResult<Category>> SearchById(int id)
        {
            var cat = await categoryDbContext.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpPut("category/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            var dbCategory = await this.categoryDbContext.Categories
                .FirstOrDefaultAsync(s => s.CatId.Equals(id));

            dbCategory.CatName = category.CatName;
            dbCategory.CatType = category.CatType;
            dbCategory.CatBudget = category.CatBudget;

            await this.categoryDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpDelete("category/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await this.categoryDbContext.Categories
                .FirstOrDefaultAsync(s => s.CatId.Equals(id));
            if (category == null)
                return BadRequest();
            this.categoryDbContext.Remove(category);
            await this.categoryDbContext.SaveChangesAsync();

            return Accepted();
        }


    }
}
