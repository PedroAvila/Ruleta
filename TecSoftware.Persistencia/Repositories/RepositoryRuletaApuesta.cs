using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public class RepositoryRuletaApuesta : IRuletaApuesta<RuletaApuesta>
    {
        public async Task Create(RuletaApuesta entity)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO RuletaApuestas(RuletaId, Numero, Color)" +
                                     " VALUES(@RuletaId, @Numero, @Color)";
                    cmd.Parameters.AddWithValue("@RuletaId", entity.RuletaId);
                    cmd.Parameters.AddWithValue("@Numero", entity.Numero);
                    cmd.Parameters.AddWithValue("@Color", entity.Color);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
