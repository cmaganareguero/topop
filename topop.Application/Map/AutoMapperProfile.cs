using AutoMapper;
using topop.Domain.Models;
using topop.Application.Dtos;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Video, AddVideoDto>().ReverseMap(); // Mapear de Video a  AddVideoDTO y viceversa
        CreateMap<Video, GetVideoDto>().ReverseMap();
    }

}
