using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class MovimientoExtend
    {
        public int MovimientoId { get; set; }
        public int OperacionId { get; set; }
        public int ApuestaId { get; set; }
        public int Numero { get; set; }
        public decimal Ingreso { get; set; }
        public StatusOperacion Estado { get; set; }
    }
}
