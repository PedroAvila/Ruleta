using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public class RepositoryApuesta : IApuesta<Apuesta>
    {
        public async Task PlaceBet(Apuesta entity)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Apuestas(RuletaId, ClienteId, Numero, Pago)" +
                                 " VALUES(@RuletaId, @ClienteId, @Numero, @Pago) SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@RuletaId", entity.RuletaId);
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                    cmd.Parameters.AddWithValue("@Pago", entity.Pago);
                    entity.ApuestaId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }
    }
}
