using AutoMapper;
using web_api.Models;
using web_api.DTOs;

namespace web_api.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractCreateDTO, Contract>();
            CreateMap<Contract, ContractReadDTO>();
        }
    }
}
