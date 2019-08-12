using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.DTOs
{
    public class JobDTO:EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }

        public int IdCategory { get; set; }
        public virtual List<PersonDTO> Persons { set; get; }
        public virtual CategoryDTO Category { get; set; }
    }
}
