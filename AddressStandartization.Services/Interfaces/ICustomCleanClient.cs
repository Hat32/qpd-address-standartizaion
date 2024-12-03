using AddressStandartization.Services.Services.Models;

namespace AddressStandartization.Services.Services.Interfaces;

public interface ICustomCleanClient
{
    Task<string> CleanAddressAsync(AddressModel address);
}