namespace CurrencyConverterApi.IService
{
    public interface IExchangeRateService
    {
        Task<string> GetLatestRatesAsync(string baseCurrency);
        Task<string> ConvertCurrencyAsync(string amount, string fromCurrency, string toCurrency);
        Task<string> GetHistoricalRatesAsync(string baseCurrency, string start, string end);
    }
}
