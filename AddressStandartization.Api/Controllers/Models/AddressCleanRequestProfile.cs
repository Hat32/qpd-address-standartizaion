using AddressStandartization.Services.Services.Models;
using AutoMapper;

namespace AddressStandartization.Api.Controllers.Models;

public class AddressCleanRequestProfile: Profile
{
    public AddressCleanRequestProfile()
    {
        CreateMap<AddressRequestModel, AddressModel>();
    }
}