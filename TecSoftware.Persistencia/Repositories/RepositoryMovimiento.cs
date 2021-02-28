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

        public async Task<List<MovimientoExtend>> GetMoveBet(int ruleta)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = 
                        "SELECT m.MovimientoId, m.OperacionId, m.ApuestaId, a.Numero, m.Ingreso, o.Estado" +
                        " FROM Movimientos AS m" +
                        " JOIN Operaciones AS o ON o.OperacionId = m.OperacionId" +
                        " JOIN Apuestas AS a ON a.ApuestaId = m.ApuestaId" +
                        " WHERE o.RuletaId = @ruleta AND o.Estado = 1";
                    cmd.Parameters.AddWithValue("@ruleta", ruleta);
                    var entity = new List<MovimientoExtend>();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var m = new MovimientoExtend()
                            {
                                MovimientoId = (int)(reader["MovimientoId"]),
                                OperacionId = (int)(reader["OperacionId"]),
                                ApuestaId = (int)(reader["ApuestaId"]),
                                Numero = (int)(reader["Numero"]),
                                Ingreso = Convert.ToDecimal((reader["Ingreso"])),
                                Estado = (StatusOperacion)(reader["Estado"])
                            };
                            entity.Add(m);
                        }
                    }
                    return entity;
                }
            }
        }
    }
}
