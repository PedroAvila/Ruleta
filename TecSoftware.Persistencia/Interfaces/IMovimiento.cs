using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public interface IMovimiento<T> where T : class
    {
        Task Create(T entity);
        Task<List<MovimientoExtend>> GetMoveBet(int ruleta);
    }
}
