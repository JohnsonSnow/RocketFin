using Application.Features.Investment.Queries.GetStockByInstrumentTickerId;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


namespace Application.Services;

public sealed class FinanceApiService
{
    private readonly HttpClient _httpClient;

    public FinanceApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;     
    }


    public async Task<FinanceApiResponse> GetQuoteAsync(string symbols, CancellationToken cancellationToken)
    {
        
        var response = await _httpClient.GetFromJsonAsync<FinanceApiResponse>($"finance/quote?region=US&lang=en&symbols={symbols}", cancellationToken);
        return response;
       
    }
}
