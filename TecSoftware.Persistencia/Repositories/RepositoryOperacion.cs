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
        public async Task<Operacion> CheckRouletteOpening(int ruleta)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT OperacionId, Estado FROM Operaciones" +
                                      " WHERE RuletaId = @ruleta";
                    cmd.Parameters.AddWithValue("@ruleta", ruleta);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            var entity = new Operacion();
                            if (reader.Read())
                            {
                                entity.OperacionId = (int)(reader["OperacionId"]);
                                entity.Estado = (EstatusOperacion)(reader["Estado"]);
                            }
                            return entity;
                        }
                        else
                            return null;
                    }
                }
            }
        }

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
