using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public class Job:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }

        public int IdCategory { get; set; }
        public virtual ICollection<Person> Persons { set; get; }
        public virtual Category Category { get; set; }
    }
}
