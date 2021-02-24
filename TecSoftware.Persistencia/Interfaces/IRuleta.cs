using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TecSoftware.Persistencia
{
    public interface IRuleta<T> where T: class
    {
        Task Create(T entity);
    }
}
