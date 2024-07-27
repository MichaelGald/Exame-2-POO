using Examen_2_de_POO.Dtos.Clientes;
using Examen_2_de_POO.Dtos.common;

namespace Examen_2_de_POO.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<ResponseDto<List<ClienteDto>>> GetClienteListAsync();
        Task<ResponseDto<ClienteDto>> GetClienteByIdAsync(Guid Id);
        Task<ResponseDto<ClienteDto>> CreateClienteAsync(CreateClienteDto dto);
        Task<ResponseDto<ClienteDto>> EditClienteByIdAsync(EditClienteDto dto, Guid Id);
        Task<ResponseDto<ClienteDto>> DeleteClienteByIdAsync(Guid Id);
    }
}
