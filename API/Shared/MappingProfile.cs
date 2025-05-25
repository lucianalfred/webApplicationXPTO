using AutoMapper;
using DTO;
using Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PedidoDeMarcacao, PedidoDeMarcacaoDTO>().ReverseMap();

    }
}
