using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdApuesta : ISdApuesta
    {
        private readonly RepositoryOperacion _repositoryOperacion = new RepositoryOperacion();
        private readonly RepositoryMovimiento _repositoryMovimiento = new RepositoryMovimiento();
        private readonly RepositoryApuesta _repositoryApuesta = new RepositoryApuesta();

        public async Task PlaceBet(Apuesta entity)
        {
            var operacion = _repositoryOperacion.CheckRouletteOpening(entity.RuletaId);
            if (operacion.Result != null)
            {
                if (operacion.Result.Estado == EstatusOperacion.Abierto)
                {
                    using (var scope = new TransactionScope())
                    {
                        await _repositoryApuesta.PlaceBet(entity);
                        var movimiento = new Movimiento()
                        {
                            OperacionId = operacion.Result.OperacionId,
                            ApuestaId = entity.ApuestaId,
                            Ingreso = entity.Pago
                        };
                        await _repositoryMovimiento.Create(movimiento);
                        scope.Complete();
                    }
                }
                else
                    throw new CustomException("La ruleta se encuentra cerrada.");
            }
            else
                throw new CustomException("La ruleta no se ha inicializado");
        }
    }
}
