using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.ServiciosDominio
{
    public interface ISdMovimiento
    {
        Task Create(Movimiento entity);
    }
}
