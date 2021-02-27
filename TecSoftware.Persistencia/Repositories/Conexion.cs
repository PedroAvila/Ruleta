using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TecSoftware.Persistencia
{
    public class Conexion
    {
        private IConfiguration _configuration;
        //public Conexion(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public Conexion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Conectar(string con)
        {
            try
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                _configuration = builder.Build();
                var cadenaConexion = _configuration.GetConnectionString("default").ToString();
                var cn = new SqlConnection(cadenaConexion);
                return cn;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error de conexión: ", ex);
            }
        }
    }
}
