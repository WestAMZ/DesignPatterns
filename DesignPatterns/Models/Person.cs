using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public class Person:Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int IdJob { get; set; }
        public virtual Job Job { get; set; }
    }
}
