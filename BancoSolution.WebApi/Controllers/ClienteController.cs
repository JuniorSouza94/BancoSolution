using BancoSolution.Domain;
using BancoSolution.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }
        //      • GetClientes
        [HttpGet]
        public IActionResult GetClientes()
        {
            return Ok(_clienteRepository.BuscarTodosClientes());
        }
        //     • GetClientesPorCpf 
        [HttpGet("{cpf}")]
        public IActionResult GetClienteByCpf(long cpf)
        {
            var clienteEncontrado = _clienteRepository.BuscarClientePorCpf(cpf);

            if(clienteEncontrado == null)
                return BadRequest(new Resposta(400, "Nenhum produto localizado!"));

            return Ok(clienteEncontrado);
        }
    }
}
