using System;
using System.ComponentModel.DataAnnotations;

namespace Cw1_w1867890_Category
{
    public class Category
    {
        [Key]
        public Int32 CatId { get; set; }

        [MaxLength(20)]
        public String CatName { get; set; }

        [MaxLength(10)]
        public String CatType { get; set; }

        public Double CatBudget { get; set; }
    }
}