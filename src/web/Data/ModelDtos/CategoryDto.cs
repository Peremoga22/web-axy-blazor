﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class CategoryDto
    {
        public int Id { get; set; } 
        public string NameCategory { get; set; } 
        public string DescriptionCategory { get; set; } 
        public DateTime CurrentDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsIncome { get; set; }
        public string NameReceipt { get; set; } 
        public decimal SumReceipt { get; set; } 
        public string NameExpenditure { get; set; } 
        public decimal SumExpenditure { get; set; } 
        public int? ExpenditureId { get; set; }
        public int? ReceiptId { get; set; }
        public decimal BalansRecipt { get; set; }
        public decimal BalansExpenditure { get; set; }
        public decimal CurrentBalance { get; set; } 
        public decimal SavingForThisMounth { get; set; } 
        public decimal BalanceTheBeginningMounth { get; set; } 

        public string SumPercentage => (this.SumExpenditure * 100) / this.SumReceipt + "%";
    }
}
