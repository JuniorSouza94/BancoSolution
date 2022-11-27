using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoRepository _contratoRepository;
        public ContratoController()
        {
            _contratoRepository = new ContratoRepository();
        }
        //      • PostContrato
        [HttpPost]
        public IActionResult PostContrato(Contrato novaContrato)
        {
            _contratoRepository.CadastraNovoContrato(novaContrato);

            return Ok(novaContrato);
        }
        //    • BuscarContratosPorCliente  
        [HttpGet("{cpf}")]
        public IActionResult GetContratosByCpf(long cpf)
        {
            var contratoEncontrado = _contratoRepository.BuscarContratosPorCliente(cpf);  
            if(contratoEncontrado == null)
                return BadRequest(new Resposta(400, "Nenhum produto localizado!"));

            return Ok(contratoEncontrado);
        }
    }
}
