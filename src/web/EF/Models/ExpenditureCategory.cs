using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace web.EF.Models
{
    public class ExpenditureCategory
    {
        [Key]
        public int ExpenditureCategoryId { get; set; }
        public string Description { get; set; }
        public decimal CurrentSum { get; set; }     
        public int ExpenditureId { get; set; }
        public bool IsShowUp { get; set; }
    }
}
