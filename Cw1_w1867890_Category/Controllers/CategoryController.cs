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
        public ActionResult<List<Category>> SearchAll()
        {
            return categoryDbContext.Categories.ToList();
            
        }

        [HttpPost("category/create")]
        public IActionResult Create(Category category)
        {
            Category c = new Category();
            c.CatName = category.CatName;
            c.CatType = category.CatType;
            c.CatBudget = Double.Parse(category.CatBudget.ToString());

            this.categoryDbContext.Categories.Add(category);
            this.categoryDbContext.SaveChanges();

            return Accepted();
        }

        [HttpGet("category/search/{id}")]
        public ActionResult<Category> SearchById(int id)
        {
            var cat = categoryDbContext.Categories.Find(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpPut("category/update/{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            var dbCategory = this.categoryDbContext.Categories
                .FirstOrDefault(s => s.CatId.Equals(id));

            dbCategory.CatName = category.CatName;
            dbCategory.CatType = category.CatType;
            dbCategory.CatBudget = category.CatBudget;

            this.categoryDbContext.SaveChanges();

            return Accepted();
        }

        [HttpDelete("category/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var category = this.categoryDbContext.Categories
                .FirstOrDefault(s => s.CatId.Equals(id));
            if (category == null)
                return BadRequest();
            this.categoryDbContext.Remove(category);
            this.categoryDbContext.SaveChanges();

            return Accepted();
        }


    }
}
