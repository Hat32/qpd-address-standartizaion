using AddressStandartization.Api.Models;
using AutoMapper;
using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;

namespace AddressStandartization.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AddressStandartizationController : ControllerBase
{
    private readonly ICleanClientAsync _cleanClientAsync;

    private readonly IMapper _mapper;
    
    
    public AddressStandartizationController(ICleanClientAsync cleanClientAsync, IMapper mapper)
    {
        _cleanClientAsync = cleanClientAsync;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStandartAddress([FromQuery] string rawAddress)
    {
        var result = await _cleanClientAsync.Clean<Address>(rawAddress);
       
        var dto = _mapper.Map<Address, StandartAddressModel>(result);
        
        return Ok(dto);
    }
}