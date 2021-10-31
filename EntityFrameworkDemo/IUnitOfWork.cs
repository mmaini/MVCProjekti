using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public interface IUnitOfWork : IDisposable
    {     
        //repozitoriji koje imamo
        IEmployeeRepository Employees { get; }   
        void SaveChanges();
    }
}
