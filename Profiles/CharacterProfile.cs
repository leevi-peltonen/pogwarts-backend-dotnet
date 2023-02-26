using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class CharacterProfile : Profile
    {
        public readonly PogwartsContext PogwartsContext;
        public CharacterProfile(PogwartsContext context) 
        {
            PogwartsContext = context;
            CreateMap<Character, CharacterReadDTO>();
            CreateMap<CharacterCreateDTO, Character>()
                .ForMember(c => c.User, opt => opt
                .MapFrom(cdto => context.User.First(u => u.Name == cdto.userName)));
        }
    }
}
