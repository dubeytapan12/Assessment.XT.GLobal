using Assessment.XT.GLobal.data;
using Assessment.XT.GLobal.Dtos;
using AutoMapper;

namespace Assessment.XT.GLobal.Profiles
{
    public class JokeProfile : Profile
    {
        public JokeProfile() { 
        CreateMap<JokeSchema,RandomJokeDtos>()
                .ForMember(dest=> dest.Setup,opt=> opt.MapFrom(src=> src.body.Count>0? src.body[0].setup: ""))
                .ForMember(dest => dest.Punchline, opt => opt.MapFrom(src => src.body.Count > 0 ? src.body[0].punchline : ""))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.body.Count > 0 ? src.body[0].type : ""));

            CreateMap<JokeCountSchema, JokeCountDto>().ReverseMap();
        }
    }
}
