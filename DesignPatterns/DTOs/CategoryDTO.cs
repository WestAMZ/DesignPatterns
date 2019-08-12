using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.DTOs
{
    public class CategoryDTO : EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<JobDTO> Jobs { get; set; }
    }
}
