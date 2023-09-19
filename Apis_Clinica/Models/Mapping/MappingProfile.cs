using AutoMapper;
using Domain.Entities;

namespace Apis_Clinica.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dentista, DentistaDTO>().ReverseMap();
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Tratamento, TratamentoDTO>().ReverseMap();
        }
    }
}
