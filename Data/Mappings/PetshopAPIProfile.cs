using AutoMapper;
using Entity;
using Entity.Dtos.Consulta;
using Entity.Dtos.Dono;
using Entity.Dtos.Pet;
using Entity.Dtos.Profissional;
using Entity.Dtos.TipoAtendimento;
using PetshopAPI.Models.Dtos;

namespace DataAccess.Mappings
{
    public class PetshopAPIProfile : Profile
    {
        public PetshopAPIProfile()
        {
            CreateMap<ConsultaDto, Consulta>()
                .ForMember(dest => dest.Profissional, opt => opt.Ignore())
                .ForMember(dest => dest.TipoAtendimento, opt => opt.Ignore());
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.TipoAtendimento, opt => opt.MapFrom(src => src.TipoAtendimento.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            CreateMap<Consulta, ConsultaDetalhesDto>();
            CreateMap<ConsultaDetalhesDto,Consulta>();
            CreateMap<ConsultaAdicionarDto,Consulta>();
            CreateMap<ConsultaAtulizarDto,Consulta>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PetAdicionarDto, Pet>();
            CreateMap<PetAtualizarDto, Pet>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
                CreateMap<Pet, PetDto>();
                CreateMap<Pet, PetDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Donos, opt => opt.MapFrom(src =>
                src.Donos.Select(x => x.Nome).ToArray()));


            CreateMap<TipoAtendimento, TipoAtendimentoDetalhesDto>();
            CreateMap<TipoAtendimento, TipoAtendimentoDto>();


            CreateMap<Dono,DonoDto>();
            CreateMap<DonoDto,Dono>();
            CreateMap<Dono, DonoDetalhesDto>().ReverseMap();
            CreateMap<DonoAdicionarDto, Dono>();
            CreateMap<DonoAtualizarDto, Dono>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.TipoAtendimentos, opt => opt.MapFrom(src =>
                src.TipoAtendimentos.Select(x => x.Nome).ToArray()));
            CreateMap<Profissional, ProfissionalDto>();

            CreateMap<ProfissionalAdicionarDto, Profissional>();
            CreateMap<ProfissionalAtualizarDto, Profissional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      
        }
    }
}
