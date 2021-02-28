using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public class RepositoryMovimiento : IMovimiento<Movimiento>
    {
        public async Task Create(Movimiento entity)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Movimientos(OperacionId, ApuestaId, Ingreso)" +
                                 " VALUES(@OperacionId, @ApuestaId, @Ingreso)";
                    cmd.Parameters.AddWithValue("@OperacionId", entity.OperacionId);
                    cmd.Parameters.AddWithValue("@ApuestaId", entity.ApuestaId);
                    cmd.Parameters.AddWithValue("@Ingreso", entity.Ingreso);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
