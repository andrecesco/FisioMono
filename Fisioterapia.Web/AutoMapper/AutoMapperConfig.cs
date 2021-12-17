using AutoMapper;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Models.Old;
using Fisioterapia.Web.ViewModels;
using Fisioterapia.Web.ViewModels.Old;

namespace Fisioterapia.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Tratamento, TratamentoViewModel>().ReverseMap();
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
            CreateMap<Anamnese, AnamneseViewModel>().ReverseMap();
            CreateMap<Convenio, ConvenioViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Conduta, CondutaViewModel>().ReverseMap();
            CreateMap<CondutaTratamento, CondutaTratamentoViewModel>().ReverseMap();

            CreateMap<PacienteOld, PacienteOldViewModel>().ReverseMap();
            CreateMap<ExameCondutaOld, ExameCondutaOldViewModel>().ReverseMap();
        }
    }
}
