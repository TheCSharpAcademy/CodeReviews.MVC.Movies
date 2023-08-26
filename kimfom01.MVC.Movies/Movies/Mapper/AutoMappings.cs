using AutoMapper;
using Movies.Models;

namespace Movies.Mapper;

public class AutoMappings : Profile
{
    public AutoMappings()
    {
        CreateMap<MovieApiDto, Movie>()
            .ForMember(mov => mov.Genre, 
            opt => opt.MapFrom(movDto => 
            string.Join(" ", movDto.Genres)))
            .ReverseMap();

        CreateMap<Movie, Details>()
            .ReverseMap();
        
        CreateMap<LikedMovie, Details>()
            .ReverseMap();
        
        CreateMap<Movie, LikedMovie>()
            .ForMember(liked => liked.Id,
                opt => opt.Ignore())
            .ReverseMap();
    }
}
