using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Persistencia
{
    public class RepositoryRuleta : IRuleta<Ruleta>
    {
        
        public async Task Create(Ruleta entity)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Ruletas(Nombre, MontoInicial, Estado) VALUES(@Nombre, @MontoInicial, @Estado) SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@MontoInicial", entity.MontoInicial);
                    cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                    entity.RuletaId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }

        public async Task<decimal> GetMaximumAmount(int Id)
        {
            using (SqlConnection cn = Conexion.Connect("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MontoInicial FROM Ruletas WHERE RuletaId = @Id";            
                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            var entity = new Ruleta();
                            if (reader.Read())
                            {
                                entity.MontoInicial = Convert.ToDecimal((reader["MontoInicial"]));
                            }
                            return entity.MontoInicial;
                        }
                        else
                            return 0M;
                    }
                }
            }
        }
    }
}
