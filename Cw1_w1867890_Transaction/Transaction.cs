using System;
using System.ComponentModel.DataAnnotations;

namespace Cw1_w1867890_Transaction
{
    public class Transaction
    {
        [Key]
        public Int32 TranId { get; set; }

        public Int32 TranCatId { get; set; }

        [MaxLength(20)]
        public String TranDescription { get; set; }

        public DateTime TranDate { get; set; }
        
        public Boolean TranRecurring { get; set; }

        public Double TranAmount { get; set; }
    }
}
