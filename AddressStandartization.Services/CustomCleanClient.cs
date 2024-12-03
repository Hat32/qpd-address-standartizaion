using System.Text;
using System.Text.Json;
using AddressStandartization.Services.Services.Exceptions;
using AddressStandartization.Services.Services.Interfaces;
using AddressStandartization.Services.Services.Models;
using Microsoft.Extensions.Logging;

namespace AddressStandartization.Services;


public class CustomCleanClient: ICustomCleanClient
{
    private readonly HttpClient _httpClient;
    
    private readonly ILogger<CustomCleanClient> _logger;
    
    public CustomCleanClient(HttpClient httpClient, ILogger<CustomCleanClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<string> CleanAddressAsync(AddressModel addressModel)
    {
        var content = SerializeContent(addressModel);
        var request = CreateRequest(content);
        
        var response = await _httpClient.SendAsync(request);
        CheckError(response);
        var result = await response.Content.ReadAsStringAsync();

        return result;
    }
    private void CheckError(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            LogResponseError(response);
            throw new CustomResponseException();
        }
    }

    private HttpRequestMessage CreateRequest(string content)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "clean/address");
        
        request.Content = new StringContent(content, Encoding.UTF8, "application/json");
        
        
        return request;
    }

    private string SerializeContent(AddressModel model)
    {
        var content = new[] { model.Address };

        return JsonSerializer.Serialize(content);
    }
    
    private void LogResponseError(HttpResponseMessage response)
    {
        _logger.LogError("Request failed. Status Code: {StatusCode}, Reason: {ReasonPhrase}, URL: {RequestUrl}",
            response.StatusCode,
            response.ReasonPhrase,
            response.RequestMessage.RequestUri);
    }
}