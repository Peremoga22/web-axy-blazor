using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.SumPies
{
    public class SumBalans : SumPieBase
    {
        // public string SumPercentage1 => (this.SumExpenditure * 100) / this.SumReceipt + "%";
        public string SumPercentage1 => this.SumReceipt - this.SumExpenditure + "";
    }
}
