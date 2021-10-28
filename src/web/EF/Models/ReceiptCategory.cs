using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class ReceiptCategory
    {
        [Key]
        public int ReceiptCategoryId { get; set; }
        public string Description { get; set; }
        public decimal CurrentSum { get; set; }
        public int ReceiptId { get; set; }
        public bool IsShowUp { get; set; }
        public DateTime DateOfIncome { get; set; }
    }
}
