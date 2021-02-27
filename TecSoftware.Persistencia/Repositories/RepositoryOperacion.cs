using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public class RepositoryOperacion : IOperacion<Operacion>
    {
        public async Task RouletteOpening(Operacion entity)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Operaciones(RuletaId, Fecha, Estado) VALUES(@RuletaId, @Fecha, @Estado) SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@RuletaId", entity.RuletaId);
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                    entity.OperacionId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }
    }
}
