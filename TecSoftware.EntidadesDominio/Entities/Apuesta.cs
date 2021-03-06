﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TecSoftware.EntidadesDominio
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public int RuletaId { get; set; }
        public int ClienteId { get; set; }
        public int Numero { get; set; }
        public decimal Pago { get; set; }
        public virtual Ruleta Ruleta { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
