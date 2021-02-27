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
    public class RuletaController : ControllerBase
    {
        private readonly ISdRuleta _sdRuleta;
        private readonly IMapper _mapper;

        public RuletaController(IMapper mapper, ISdRuleta sdRuleta)
        {
            _mapper = mapper;
            _sdRuleta = sdRuleta;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RuletaDto ruletaDto)
        {
            var ruleta = _mapper.Map<Ruleta>(ruletaDto);
            await _sdRuleta.Create(ruleta);
            ruletaDto = _mapper.Map<RuletaDto>(ruleta);
            return Ok(ruletaDto);
        }
    }
}
