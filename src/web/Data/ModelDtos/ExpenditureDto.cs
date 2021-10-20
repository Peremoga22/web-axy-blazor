using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.ModelDtos
{
    public class ExpenditureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
    }
}
