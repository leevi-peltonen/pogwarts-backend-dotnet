using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponReadDTO>()
                .ForMember(wrdto => wrdto.Rarity, opt => opt
                .MapFrom(w => Enum.GetName(typeof(Rarity), w.Rarity)));

            CreateMap<WeaponReadDTO, Weapon>();

                
        }
    }
}
