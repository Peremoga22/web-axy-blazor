﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CurentData { get; set; }

        public bool IsIncome { get; set; }
        [ForeignKey("ReceiptId")]
        public virtual Receipt Receipts { get; set; }
        [ForeignKey("ExpenditureId")]
        public virtual Expenditure Expenditures { get; set; }
    }
}
