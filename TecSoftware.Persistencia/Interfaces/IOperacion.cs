using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TecSoftware.Persistencia
{
    public interface IOperacion<T> where T: class
    {
        Task RouletteOpening(T entity);
    }
}
