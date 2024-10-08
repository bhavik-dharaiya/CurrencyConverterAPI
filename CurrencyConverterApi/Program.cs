using CurrencyConverterApi.IService;
using CurrencyConverterApi.Service;
using Polly;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>();

//// Add services to the container with base API url.
//builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>(client =>
//{
//    client.BaseAddress = new Uri("https://api.frankfurter.app/");
//});

//// Add services to the container, base API url and bulk handle request.
builder.Services.AddHttpClient<IExchangeRateService, ExchangeRateService>(client =>
{
    client.BaseAddress = new Uri("https://api.frankfurter.app/");
}).AddPolicyHandler(Policy.BulkheadAsync<HttpResponseMessage>(maxParallelization: 10, maxQueuingActions: 50)); // Simple rate limiting example

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
