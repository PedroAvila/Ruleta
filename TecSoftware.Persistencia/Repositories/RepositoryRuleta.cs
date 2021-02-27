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
        private static IConfiguration _configuration { get; }
        public Conexion _conexion = new Conexion(_configuration);

        public async Task Create(Ruleta entity)
        {
            using (SqlConnection cn = _conexion.Conectar("default"))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Ruletas(Nombre, Estado) VALUES(@Nombre, @Estado) SELECT SCOPE_IDENTITY()";
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Estado", entity.Estado);
                    entity.RuletaId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
        }
    }
}
