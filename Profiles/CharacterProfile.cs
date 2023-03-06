using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class CharacterProfile : Profile
    {
        private readonly PogwartsContext _context;
        public CharacterProfile(PogwartsContext context) 
        {
            _context = context;
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(dest => dest.Achievements, opt => opt.MapFrom(src => src.Achievements.Select(a => a.AchievementId)));

            CreateMap<CharacterCreateDTO, Character>()
                .ForMember(c => c.User, opt => opt
                .MapFrom(cdto => _context.User.First(u => u.Name == cdto.userName)))
                .ForMember(c => c.EquippedWeapon, opt => opt
                .MapFrom(cdto => _context.Weapon.First(w => w.Name == cdto.weaponName)));
        }
    }
}
