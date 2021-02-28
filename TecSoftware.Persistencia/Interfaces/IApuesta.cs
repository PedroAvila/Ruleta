using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TecSoftware.Persistencia
{
    public interface IApuesta<T> where T : class
    {
        Task PlaceBet(T entity);
    }
}
