using AutoMapper;
using Dadata.Model;

namespace AddressStandartization.Api.Models.Profiles;

public class StandartAddressProfile : Profile
{
    public StandartAddressProfile()
    {
        CreateMap<Address, StandartAddressModel>();
    } 
}