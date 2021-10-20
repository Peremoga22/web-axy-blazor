using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
    }
}
