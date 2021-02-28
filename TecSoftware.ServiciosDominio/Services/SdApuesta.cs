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
            if (entity.Numero >= 0 && entity.Numero <= 36)
            {
                var operacion = _repositoryOperacion.CheckRouletteOpening(entity.RuletaId);
                if (operacion.Result != null)
                {
                    if (operacion.Result.Estado == StatusOperacion.Abierto)
                    {
                        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                        {
                            await _repositoryApuesta.PlaceBet(entity);
                            await CreateMovimiento(operacion.Result.OperacionId, entity.ApuestaId, entity.Pago);
                            scope.Complete();
                        }
                    }
                    else
                        throw new CustomException("La ruleta se encuentra cerrada.");
                }
                else
                    throw new CustomException("La ruleta no se ha inicializado.");
            }
            else
                throw new CustomException("El número que aposto no es valido.");
        }

        private async Task CreateMovimiento(int operacion, int apuesta, decimal ingreso)
        {
            var movimiento = new Movimiento()
            {
                OperacionId = operacion,
                ApuestaId = apuesta,
                Ingreso = ingreso
            };
            await _repositoryMovimiento.Create(movimiento);
        }
    }
}
