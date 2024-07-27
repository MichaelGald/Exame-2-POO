using AutoMapper;
using Examen_2_de_POO.Databases.Entities;
using Examen_2_de_POO.Dtos.Clientes;
using Examen_2_de_POO.Dtos.Planamortiguacion;


namespace Examen_2_de_POO.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForCliente();
            MapsForPlanAmortiguacion();
        }

        private void MapsForCliente()
        {
            CreateMap<ClienteEntity, ClienteDto>();
            CreateMap<CreateClienteDto, ClienteEntity>().ForMember(dest => dest.Tasacomision, opt => opt.MapFrom(src => src.tasacomicion));
        }

        private void MapsForPlanAmortiguacion()
        {
            CreateMap<PlanamortizacionEntity, PlanAmortiguacionDto>();
        }
    }
}
    

