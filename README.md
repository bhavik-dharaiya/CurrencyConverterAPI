# Currency Converter API
The Currency Converter API is a RESTful service built using C# and ASP.NET Core, leveraging the Frankfurter API to provide exchange rates and currency conversion functionalities. The application includes three main endpoints:

## Description
1.	Retrieve the latest exchange rates for a specific base currency.
2.	Convert amounts between different currencies, excluding TRY, PLN, THB, and MXN.
3.	Return a set of historical rates for a given period using pagination.

## Getting Started

### Dependencies
* .NET SDK 7.0 or higher
* Visual Studio 2022 or higher (optional but recommended for development)
* Internet connection for API access
* Windows, macOS, or Linux operating system

### Project Structure
```
CurrencyConverterApi/
│
├── Controllers/
│   └── ExchangeRateController.cs        # API Controllers
|
├── IServices/
│   └── IExchangeRateService.cs          # Service interface
|
├── Services/
│   └── ExchangeRateService.cs           # Service implementation
|
├── appsettings.json                     # Configuration file
├── Program.cs                           # Application entry point and DI setup
|
CurrencyConverterApiTests/
|
├── ExchangeRateServiceTests.cs         # Unit tests for the service
```

### Setup and Installation
* Step 1: Clone the Repository
```
git clone https://github.com/bhavik-dharaiya/CurrencyConverterAPI.git
```

```
cd CurrencyConverterApi
```

* Step 2: Install Dependencies
```
dotnet restore
```

* Step 3: Click on the CurrencyConverterApi.sln
```
build the application and run
```

### Configuration
* API Configuration: The API uses the Frankfurter API as its data source. The base URL is set in the service class and can be adjusted if needed.
* Base API URL: Frankfurter API: https://api.frankfurter.app/
* Retry and Rate Limiting: Polly is used for retrying policies to handle transient errors from the Frankfurter API. Bulkhead Isolation is used to limit the number of concurrent requests to avoid overloading the API.

### API Endpoints
* Endpoint 1: Retrieve Latest Exchange Rates
   * Parameters: baseCurrency (query parameter, required) - The base currency code (e.g., EUR).
* Endpoint 2: Convert Currency
   * Parameters: amount, from, to - with appropriate validations.
   * Special Handling: Returns a 400 Bad Request if converting to TRY, PLN, THB, or MXN.
* Endpoint 3: Retrieve Historical Rates
   * Parameters: baseCurrency, start, end, pageSize.

### Error Handling and Logging
* Error Handling: Includes try-catch blocks with appropriate HTTP status codes.
* Logging: Uses ASP.NET Core's built-in logging framework.

### Testing and Unit Tests
* Unit tests implemented using Xunit and Moq.

### User Guide
* Using Swagger UI
  * Navigate to http://localhost:7140/swagger in your browser.
  * Test endpoints interactively.

### Consuming the API
* Use GET requests with appropriate parameters as documented.

### Troubleshooting
* Common Issues: Check parameter formats and API accessibility.
* Logs and Debugging: Use console logs for tracing errors.

## Authors
* Bhavesh Dharaiya

## Version History
* 0.1
    * Initial Release

## Acknowledgments
Inspiration, code snippets, etc.
