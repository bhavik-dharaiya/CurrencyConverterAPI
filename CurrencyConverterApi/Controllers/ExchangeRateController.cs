using CurrencyConverterApi.IService;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterApi.Controllers
{
    public class ExchangeRateController : ControllerBase
    {
        private readonly string[] _excludedCurrencies = { "TRY", "PLN", "THB", "MXN" };
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        // Retrieve the latest exchange rates for a specific currency
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestRates([FromQuery] string baseCurrency = "EUR")
        {
            if (string.IsNullOrWhiteSpace(baseCurrency))
                return BadRequest("Base currency is required.");

            try
            {
                var rates = await _exchangeRateService.GetLatestRatesAsync(baseCurrency);
                return Ok(rates);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }

        // Convert amounts between different currencies with exclusions
        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] string amount, [FromQuery] string fromCurrency, [FromQuery] string toCurrency)
        {
            if (string.IsNullOrWhiteSpace(amount) || string.IsNullOrWhiteSpace(fromCurrency) || string.IsNullOrWhiteSpace(toCurrency))
                return BadRequest("Amount, fromCurrency, and toCurrency are required.");

            if (_excludedCurrencies.Contains(fromCurrency.ToUpper()) || _excludedCurrencies.Contains(toCurrency.ToUpper()))
                return BadRequest("Conversions for TRY, PLN, THB, and MXN are not allowed.");

            try
            {
                var conversionResult = await _exchangeRateService.ConvertCurrencyAsync(amount, fromCurrency, toCurrency);
                return Ok(conversionResult);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }

        // Retrive historical rates for a given period with pagination
        [HttpGet("historical")]
        public async Task<IActionResult> GetHistoricalRates([FromQuery] string start, [FromQuery] string end, [FromQuery] string baseCurrency = "EUR", [FromQuery] int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end) || string.IsNullOrWhiteSpace(baseCurrency))
                return BadRequest("Start date, end date and currency are required.");

            if (!DateTime.TryParse(start, out DateTime startDate) || !DateTime.TryParse(end, out DateTime endDate))
                return BadRequest("Invalid date format. Please use yyyy-MM-dd.");

            if (startDate > endDate)
                return BadRequest("Start date must be before the end date.");

            endDate = endDate > DateTime.Today ? DateTime.Today : endDate;

            try
            {
                var currentStartDate = startDate;
                var historicalRates = new List<string>();

                while (currentStartDate <= endDate)
                {
                    var currentEndDate = currentStartDate.AddDays(pageSize - 1);
                    if (currentEndDate > endDate)
                        currentEndDate = endDate;

                    var rates = await _exchangeRateService.GetHistoricalRatesAsync(baseCurrency, currentStartDate.ToString("yyyy-MM-dd"), currentEndDate.ToString("yyyy-MM-dd"));
                    historicalRates.Add(rates);

                    currentStartDate = currentEndDate.AddDays(1);
                }

                return Ok(historicalRates);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }
    }
}
