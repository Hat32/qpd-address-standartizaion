using AddressStandartization.Api.Controllers.Models;
using AddressStandartization.Api.Models;
using AddressStandartization.Services.Services.Interfaces;
using AddressStandartization.Services.Services.Models;
using AutoMapper;
using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;

namespace AddressStandartization.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AddressStandartizationController : ControllerBase
{
    private readonly ICustomCleanClient _cleanClient;

    private readonly IMapper _mapper;
    
    
    public AddressStandartizationController(ICustomCleanClient cleanClient, IMapper mapper)
    {
        _cleanClient = cleanClient;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStandartAddress([FromQuery] AddressRequestModel request)
    {
        var model = _mapper.Map<AddressModel>(request);
        
        var result = await _cleanClient.CleanAddressAsync(model);
        
        return Ok(result);
    }
}