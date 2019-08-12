using DesignPatterns.Data.IRespositories;
using DesignPatterns.Data.Repositories;
using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Data.IBase
{
    public class UnitOfWork:IUnitOfWork
    {
        protected ApplicationContext _Context ;
        public IPersonRepository Persons { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _Context = context;
            Persons = new PersonRepository(context);
        }

        public void Commit()
        {
            _Context.SaveChanges();
        }
        #region("Dispose implementation")
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
