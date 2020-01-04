using AccountOwnerServer.Dto;
using AutoMapper;
using Entities.Extensions;
using Entities.Models;

namespace AccountOwnerServer.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Owner, OwnerForCreationDto>()
                .ForAllMembers(option => option.Condition(source => source!=null));
            CreateMap<Owner, OwnerForUpdateDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}