using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class ExpenditureCategoryDto
    {
        public int ExpenditureCategoryId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal CurrentSum { get; set; }
        public int ExpenditureId { get; set; }
        public bool IsShowUp { get; set; }
        public decimal CurrentAllSum { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
