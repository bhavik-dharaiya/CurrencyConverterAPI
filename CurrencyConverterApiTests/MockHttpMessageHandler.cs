using Moq;

namespace CurrencyConverterApiTests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Mock<HttpMessageHandler> _mockHandler;

        public MockHttpMessageHandler(Mock<HttpMessageHandler> mockHandler)
        {
            _mockHandler = mockHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _mockHandler.Object.SendAsync(request, cancellationToken);
        }

        public Mock<HttpMessageHandler> Mock => _mockHandler;
    }
}
