using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatterns.Models;
namespace DesignPatterns.Data.IRespositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        ICollection<Person> GetByJob(string job);
        ICollection<Person> GetByCategoryJob(string Category);
    }
}
