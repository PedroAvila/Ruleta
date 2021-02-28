using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class ApuestaDto
    {
        public int ApuestaId { get; set; }
        public int RuletaId { get; set; }
        public int ClienteId { get; set; }
        public int Numero { get; set; }
        public decimal Pago { get; set; }
    }
}
