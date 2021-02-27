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
    public class OperacionController : ControllerBase
    {
        private readonly ISdOperacion _sdOperacion;
        private readonly IMapper _mapper;

        public OperacionController(IMapper mapper, ISdOperacion sdOperacion)
        {
            _mapper = mapper;
            _sdOperacion = sdOperacion;
        }

        [HttpPost]
        public async Task<IActionResult> RouletteOpening(OperacionDto operacionDto)
        {
            string mesage = string.Empty;
            try
            {
                var fecha1 = Convert.ToDateTime(operacionDto.Fecha);
                operacionDto.Fecha = fecha1.ToString("yyyy-MM-ddTHH:mm:ssZ");
                var operacion = _mapper.Map<Operacion>(operacionDto);
                await _sdOperacion.RouletteOpening(operacion);
                operacionDto = _mapper.Map<OperacionDto>(operacion);
            }
            catch (CustomException ex)
            {
                mesage = ex.Message;   
            }
            return Ok(mesage);
        }
    }
}
