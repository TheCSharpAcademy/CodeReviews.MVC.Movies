using AutoMapper;
using Movies.Models;
using Movies.Models.APIModels;

namespace Movies.Mapper;

public class AutoMappings : Profile
{
    public AutoMappings()
    {
        CreateMap<MovieDto, Movie>()
            .ForMember(mov => mov.Genre, 
            opt => opt.MapFrom(movDto => 
            string.Join(" ", movDto.Genres)));
    }
}
