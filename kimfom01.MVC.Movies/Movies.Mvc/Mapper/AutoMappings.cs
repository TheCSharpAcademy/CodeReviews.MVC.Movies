using AutoMapper;
using Movies.ApiService.Models;
using Movies.DataAccessLibrary.Models;
using Movies.Mvc.Models;

namespace Movies.Mapper;

public class AutoMappings : Profile
{
    public AutoMappings()
    {
        CreateMap<MovieApiDto, MovieDbDto>()
            .ForMember(mov => mov.Genre, 
            opt => opt.MapFrom(movDto => 
            string.Join(" ", movDto.Genres)));

        CreateMap<MovieDbDto, Movie>();
        CreateMap<MovieDbDto, Details>();
    }
}
