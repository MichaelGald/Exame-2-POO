using AutoMapper;
using Examen_2_de_POO.Databases.Entities;
using Examen_2_de_POO.Dtos.Clientes;


namespace Examen_2_de_POO.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForCliente();
        }

        private void MapsForCliente()
        {
            CreateMap<ClienteEntity, ClienteDto>();
            CreateMap<CreateClienteDto, ClienteEntity>();
            CreateMap<EditClienteDto, ClienteEntity>();
        }
    }
}
