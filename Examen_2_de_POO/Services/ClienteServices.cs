using Examen_2_de_POO.API.Helpers;
using Examen_2_de_POO.Databases;
using Examen_2_de_POO.Dtos.Clientes;
using Examen_2_de_POO.Dtos.common;
using Examen_2_de_POO.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Examen_2_de_POO.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly ContextClientes _context;
        private readonly AutoMapperProfile _mapper;

        public ClienteServices(ContextClientes context, AutoMapperProfile autoMapper) {
            this._context = context;
            this._mapper = autoMapper;
        }

        public async Task<ResponseDto<List<ClienteDto>>> GetClienteListAsync()
        {
            var clientesEntity = await _context.Clientes.ToListAsync();
            var categories = _mapper.Map<List<ClienteDto>>(clientesEntity);

            return new ResponseDto<List<ClienteDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de Categorias Obtenida Correctamente",
                Data = categories
            };
        }


        public async Task<ResponseDto<ClienteDto>> GetClienteByIdAsync(Guid Id)
        {
            var clienteEntity = await _context.Clientes.FirstOrDefaultAsync(j => j.IdCliente == Id);
            if (clienteEntity == null)
            {
                return new ResponseDto<ClienteDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se Encontro el Registro"
                };
            }
            var categoryDto = _mapper.Map<ClienteDto>(clienteEntity);

            return new ResponseDto<ClienteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro encontrado",
                Data = categoryDto

            };
        }

        public async Task<ResponseDto<ClienteDto>> CreateClienteAsync(CreateClienteDto dto)
        {
            var categoryEntity = _mapper.Map<ClienteEntity>(dto);
            _context.Clientes.Add(categoryEntity);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<ClienteDto>(categoryEntity);
            return new ResponseDto<ClienteDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Regigistro Creado",
                Data = categoryDto
            };
        }

        public Task<ResponseDto<ClienteDto>> EditClienteByIdAsync(EditClienteDto dto, Guid Id)
        {
            throw new NotImplementedException();
        }


        public Task<ResponseDto<ClienteDto>> DeleteClienteByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }




    }
        
    
}
