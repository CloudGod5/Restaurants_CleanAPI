using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForcastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForcastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    [Route("{take}/example")]
    public IEnumerable<WeatherForecast> Get([FromQuery] int max, [FromRoute]int take)
    {
        var result = _weatherForecastService.Get();
        return result;
    }
    
    [HttpGet("currentDay")]
    public WeatherForecast GetCurrentDayForecast()
    {
        var result = _weatherForecastService.Get().First();
        return result;
    }
}
