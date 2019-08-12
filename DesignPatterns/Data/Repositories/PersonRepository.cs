using DesignPatterns.Data.IBase;
using DesignPatterns.Data.IRespositories;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesignPatterns.Data.Repositories
{
    public class PersonRepository : Repository<Person>,IPersonRepository
    {
        public PersonRepository(ApplicationContext context):base(context)
        {
        }

        public ICollection<Person> GetByCategoryJob(string Category)
        {
            throw new NotImplementedException();
        }

        public ICollection<Person> GetByJob(string job)
        {
            throw new NotImplementedException();
        }
    }
}
