using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdRuleta : ISdRuleta
    {
        private readonly RepositoryRuleta _repositoryRuleta = new RepositoryRuleta();

        public async Task Create(Ruleta entity)
        {
            await _repositoryRuleta.Create(entity);
        }
    }
}
