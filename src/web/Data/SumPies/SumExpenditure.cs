using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.SumPies
{
    public class SumExpenditure : SumPieBase
    {
        public string SumPercentage2 => this.SumReceipt - this.SumExpenditure +"";
    }
}
