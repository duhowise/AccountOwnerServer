using AccountOwnerServer.Dto;
using AutoMapper;
using Entities.Models;

namespace AccountOwnerServer.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}