using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdApuesta : ISdApuesta
    {
        private readonly RepositoryOperacion _repositoryOperacion = new RepositoryOperacion();
        private readonly RepositoryApuesta _repositoryApuesta = new RepositoryApuesta();

        public async Task PlaceBet(Apuesta entity)
        {
            var operacion = _repositoryOperacion.CheckRouletteOpening(entity.RuletaId);
            if (operacion != null)
            {
                if (operacion.Result.Estado == EstatusOperacion.Abierto)
                {
                    await _repositoryApuesta.PlaceBet(entity);
                }
                else
                    throw new CustomException("La ruleta se encuentra cerrada.");

            }
            
        }
    }
}
