using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserReadDTO>();
        }
    }
}
