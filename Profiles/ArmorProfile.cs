using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class ArmorProfile : Profile
    {
        public ArmorProfile()
        {
            CreateMap<Armor, ArmorReadDTO>();
        }
    }
}
