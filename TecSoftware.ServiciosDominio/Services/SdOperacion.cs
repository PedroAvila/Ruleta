using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdOperacion : ISdOperacion
    {
        private readonly RepositoryOperacion _repositoryOperacion = new RepositoryOperacion();
        private readonly RepositoryRuleta _repositoryRuleta = new RepositoryRuleta();

        public async Task RouletteOpening(Operacion entity)
        {
            decimal maximumAmount = await _repositoryRuleta.GetMaximumAmount(entity.RuletaId);
            if (maximumAmount > 0M && maximumAmount <= 10_000.00M)
            {
                await _repositoryOperacion.RouletteOpening(entity);
                throw new CustomException("Operación exitosa.");
            }
            else
                throw new CustomException("Operación denegada.");
        }
    }
}
