using CurrencyConverterApi.Service;
using Microsoft.Extensions.Logging;
using Moq;

namespace CurrencyConverterApiTests
{
    public class ExchangeRateServiceTest
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeRateServiceTest()
        {
            // Create a mocked HttpMessageHandler
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://api.frankfurter.app/")
            };

            // Initialize the service with the mocked HttpClient
            _exchangeRateService = new ExchangeRateService(_httpClient, new Mock<ILogger<ExchangeRateService>>().Object);
        }

        [Fact]
        public async Task GetLatestRatesAsync_ReturnsLatestRates_WhenApiResponseIsValid()
        {
            // Arrange
            var baseCurrency = "EUR";
            var expectedResponse = "{\"base\":\"EUR\",\"rates\":{\"USD\":1.2,\"GBP\":0.9}}";

            //_httpMessageHandlerMock.Setup(m => m.SendAsync(It.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == new Uri($"https://api.frankfurter.app/latest?from={baseCurrency}")), It.IsAny<CancellationToken>())).ReturnsAsync(new HttpResponseMessage
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new StringContent(expectedResponse),
            //});

            // Act
            var result = await _exchangeRateService.GetLatestRatesAsync(baseCurrency);

            // Assert
            Assert.NotNull(result);
            //Assert.Equal("EUR", result.Base);
            //Assert.Equal(1.2m, result.Rates["USD"]);
            //Assert.Equal(0.9m, result.Rates["GBP"]);
        }
    }
}