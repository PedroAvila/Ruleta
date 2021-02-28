using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.ServiciosDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaApuestaController : ControllerBase
    {
        private readonly ISdRuletaApuesta _sdRuletaApuesta;
        private readonly IMapper _mapper;

        public RuletaApuestaController(IMapper mapper, ISdRuletaApuesta sdRuletaApuesta)
        {
            _mapper = mapper;
            _sdRuletaApuesta = sdRuletaApuesta;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RuletaApuestaDto ruletaApuestaDto)
        {
            var ruletaApuesta = _mapper.Map<RuletaApuesta>(ruletaApuestaDto);
            await _sdRuletaApuesta.Create(ruletaApuesta);
            ruletaApuestaDto = _mapper.Map<RuletaApuestaDto>(ruletaApuesta);
            return Ok(ruletaApuestaDto);
        }
    }
}
