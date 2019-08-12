using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
