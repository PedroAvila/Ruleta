using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class Ruleta
    {
        public int RuletaId { get; set; }
        public string Nombre { get; set; }
        public decimal MontoInicial { get; set; }
        public StatusRuleta Estado { get; set; }

        public virtual ICollection<RuletaApuesta> RuletaApuestas { get; set; }
    }
}
