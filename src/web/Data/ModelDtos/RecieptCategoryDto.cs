using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class RecieptCategoryDto
    {
        public int RecieptCategoryId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal CurrentSum { get; set; }
        public int RecieptId { get; set; }
        public bool IsShowUp { get; set; }
        public decimal CurrentAllSum { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
