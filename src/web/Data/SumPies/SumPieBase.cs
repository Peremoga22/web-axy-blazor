using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.SumPies
{
    public abstract class SumPieBase
    {
        public int CategoryId { get; set; }
        public string NameCategory { get; set; }

        public decimal SumReceipt { get; set; }
        public decimal SumExpenditure { get; set; }
    }
}
