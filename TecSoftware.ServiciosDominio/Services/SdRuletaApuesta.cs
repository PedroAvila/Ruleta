using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdRuletaApuesta : ISdRuletaApuesta
    {
        private readonly RepositoryRuletaApuesta _repositoryRuletaApuesta = new RepositoryRuletaApuesta();

        public async Task Create(RuletaApuesta entity)
        {
            await _repositoryRuletaApuesta.Create(entity);
        }
    }
}
