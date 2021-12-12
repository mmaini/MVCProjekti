using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
