using AutoMapper;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;

namespace Fisioterapia.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Tratamento, TratamentoViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Anamnese, AnamneseViewModel>().ReverseMap();
        }
    }
}
