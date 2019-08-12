using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.DTOs
{
    public class PersonDTO : EntityDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int IdJob { get; set; }
        public virtual JobDTO Job { get; set; }
    }
}
