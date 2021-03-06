﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.ServiciosDominio
{
    public interface ISdOperacion
    {
        Task RouletteOpening(Operacion entity);
        Task<Operacion> CheckRouletteOpening(int ruleta);
    }
}
