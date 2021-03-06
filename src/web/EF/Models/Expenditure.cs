using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class Expenditure
    {
        [Key]
        public int ExpenditureId { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
        [ForeignKey("ExpenditureCategoryId")]
        public virtual ExpenditureCategory ExpenditureCategories { get; set; }
    }
}
