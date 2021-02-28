using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.ServiciosDominio;

namespace TecSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuestaController : ControllerBase
    {
        private readonly ISdApuesta _sdApuesta;
        private readonly IMapper _mapper;

        public ApuestaController(IMapper mapper, ISdApuesta sdApuesta)
        {
            _mapper = mapper;
            _sdApuesta = sdApuesta;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApuestaDto apuestaDto)
        {
            try
            {
                //apuestaDto.Pago = Math.Truncate(apuestaDto.Pago * 100M) / 100M;
                var apuesta = _mapper.Map<Apuesta>(apuestaDto);
                await _sdApuesta.PlaceBet(apuesta);
                apuestaDto = _mapper.Map<ApuestaDto>(apuesta);
                return Ok(apuestaDto);
            }
            catch (CustomException ex)
            {
                return Ok(ex.Message);
            }
            
        }
    }
}
