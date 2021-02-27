using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class OperacionDto
    {
        public int OperacionId { get; set; }
        public int RuletaId { get; set; }
        public string Fecha { get; set; }
        public EstatusOperacion Estado { get; set; }
    }
}
