using Application.Interfaces;
using Domain.Investimento;
using Microsoft.AspNetCore.Mvc;

namespace cdb_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CdbController : ControllerBase
    {        
        private readonly ICdbCalculoService _cdbCalculoService;

        public CdbController(ICdbCalculoService cdbCalculoService)
        {
            _cdbCalculoService = cdbCalculoService;
        }

        [HttpPost("Calcular")]
        public IActionResult GetCalculo([FromBody] InvestimentoCdb input)
        {
            var result = _cdbCalculoService.Calcular(input);

            return Ok(result);
        }        
    }
}