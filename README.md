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

CurrencyConverterApiTests/
|
├── ExchangeRateServiceTests.cs      # Unit tests for the service
```

### Setup and Installation
* How to run the program
* Step 1: Clone the Repository
```
git clone https://github.com/your-repo/CurrencyConverterApi.git
git clone https://github.com/bhavik-dharaiya/CurrencyConverterAPI/
cd CurrencyConverterApi
```

## Help
Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors
Contributors names and contact info
ex. Dominique Pizzie  
ex. [@DomPizzie](https://twitter.com/dompizzie)

## Version History
* 0.2
    * Various bug fixes and optimizations
    * See [commit change]() or See [release history]()
* 0.1
    * Initial Release

## License
This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments
Inspiration, code snippets, etc.
* [awesome-readme](https://github.com/matiassingers/awesome-readme)
* [PurpleBooth](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2)
* [dbader](https://github.com/dbader/readme-template)
* [zenorocha](https://gist.github.com/zenorocha/4526327)
* [fvcproductions](https://gist.github.com/fvcproductions/1bfc2d4aecb01a834b46)
