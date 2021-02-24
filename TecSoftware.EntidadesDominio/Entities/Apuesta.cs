using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public int RuletaApuestaId { get; set; }
        public int ClienteId { get; set; }
        public decimal Pago { get; set; }
    }
}
