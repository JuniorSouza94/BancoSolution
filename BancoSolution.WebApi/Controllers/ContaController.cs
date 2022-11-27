using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _contaRepository;
        public ContaController()
        {
            _contaRepository = new ContaRepository();
        }
        //      • PostConta
        [HttpPost]
        public IActionResult PostConta(Conta novaConta)
        {
            _contaRepository.CadastraNovaConta(novaConta);

            if(novaConta == null)
                return BadRequest(new Resposta(400, "Nenhum produto localizado!"));

            return Ok(novaConta);
        }
        //     • GetContas
        [HttpGet]
        public IActionResult GetContas()
        {            
            return Ok(_contaRepository.BuscarTodasContas());
        }
        //      • GetContasPorCliente
        [HttpGet("{cpf}")]
        public IActionResult GetContaByCpf(long cpf)
        {
            var contaEncontrada = _contaRepository.BuscarContasPorCliente(cpf);
            if(contaEncontrada == null)
                return BadRequest(new Resposta(400, "Nenhum produto localizado!"));

            return Ok(contaEncontrada);
        }
    }
}
