using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoManagementPlatform.Application.UseCases.Customer;

namespace PhotoManagementPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<Customer> Get()
        {

            var result = await _mediator.Send(new GetCustomerByIdUseCase());

            return result;
        }
    }
}