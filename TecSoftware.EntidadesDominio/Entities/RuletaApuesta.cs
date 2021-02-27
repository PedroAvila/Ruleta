using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class RuletaApuesta
    {
        public int RuletaApuestaId { get; set; }
        public int RuletaId { get; set; }
        public int Numero { get; set; }
        public string Color { get; set; }

        public virtual Ruleta Ruleta { get; set; }
    }
}
