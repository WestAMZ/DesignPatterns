using DesignPatterns.Data.IRespositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Data.IBase
{
    interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
