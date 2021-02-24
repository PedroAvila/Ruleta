using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }
        public int OperacionId { get; set; }
        public int ApuestaId { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal Ingreso { get; set; }
    }
}
