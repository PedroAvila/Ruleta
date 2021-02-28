using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.ServiciosDominio
{
    public class SdMovimiento : ISdMovimiento
    {
        private readonly RepositoryMovimiento _repositoryMovimiento = new RepositoryMovimiento();

        public async Task ClosingBets(int ruleta)
        {
            string color = string.Empty;
            Random random = new Random();
            int randomNumber = random.Next(0, 37);

            var result = _repositoryMovimiento.GetMoveBet(ruleta).Result.ToList();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    if (item.Numero == randomNumber)
                    {
                        if ((item.Numero % 2) == 0)
                            color = "ROJO";
                        else
                            color = "NEGRO";
                    }
                }
            }
            return;
        }

        public async Task Create(Movimiento entity)
        {
            await _repositoryMovimiento.Create(entity);
        }
    }
}
