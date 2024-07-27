using Examen_2_de_POO.Dtos.Clientes;
using Examen_2_de_POO.Dtos.common;
using Examen_2_de_POO.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_2_de_POO.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            this._clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ClienteDto>>>> GetAll()
        {
            var response = await _clienteServices.GetClienteListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ClienteDto>>> Get(Guid id)
        {
            var response = await _clienteServices.GetClienteByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ClienteDto>>> Create(CreateClienteDto dto)
        {
          var respose = await _clienteServices.CreateClienteAsync(dto);
            return StatusCode(respose.StatusCode, respose);
        }
    }
}

