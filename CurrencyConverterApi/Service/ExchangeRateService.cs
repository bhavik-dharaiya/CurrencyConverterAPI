using CurrencyConverterApi.IService;
using Polly;
using Polly.Retry;

namespace CurrencyConverterApi.Service
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<ExchangeRateService> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public ExchangeRateService(HttpClient httpClient, ILogger<ExchangeRateService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            // Configure Polly retry policy
            _retryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode).WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (outcome, timespan, retryAttempt, context) =>
            {
                _logger.LogWarning($"Request failed with {outcome.Result.StatusCode}. Waiting {timespan} before retry #{retryAttempt}.");
            });
        }

        public async Task<string> GetLatestRatesAsync(string baseCurrency)
        {
            //var response = await _httpClient.GetAsync($"https://api.frankfurter.app/latest?from={baseCurrency}");
            var response = await _httpClient.GetAsync($"latest?from={baseCurrency}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ConvertCurrencyAsync(string amount, string fromCurrency, string toCurrency)
        {
            //var response = await _httpClient.GetAsync($"https://api.frankfurter.app/latest?amount={amount}&from={fromCurrency}&to={toCurrency}");
            var response = await _httpClient.GetAsync($"latest?amount={amount}&from={fromCurrency}&to={toCurrency}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetHistoricalRatesAsync(string baseCurrency, string start, string end)
        {
            //var response = await _httpClient.GetAsync($"https://api.frankfurter.app/{start}..{end}?from={baseCurrency}");
            var response = await _httpClient.GetAsync($"{start}..{end}?from={baseCurrency}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
