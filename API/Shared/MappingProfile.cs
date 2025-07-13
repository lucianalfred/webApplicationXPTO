using AutoMapper;
using DTO;
using Model;

namespace Shared 
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoDeMarcacao, PedidoDeMarcacaoDTO>().ReverseMap();

        }
    }

    public class UtilizadorProfile : Profile
    {
        public UtilizadorProfile()
        {
            CreateMap<Utilizador, UtilizadorDTO>().ReverseMap();
        }
    }

}