using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdMovimiento : ISdMovimiento
    {
        private readonly RepositoryMovimiento _repositoryMovimiento = new RepositoryMovimiento();

        public async Task Create(Movimiento entity)
        {
            await _repositoryMovimiento.Create(entity);
        }
    }
}
