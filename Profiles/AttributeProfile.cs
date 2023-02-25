using AutoMapper;
using web_api.Models;
using web_api.DTOs;
using Attribute = web_api.Models.Attribute;

namespace web_api.Profiles
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<Attribute, AttributeReadDTO>();
        }
    }
}
