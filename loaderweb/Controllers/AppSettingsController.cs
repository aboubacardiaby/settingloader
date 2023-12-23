using Microsoft.AspNetCore.Mvc;

namespace loaderweb.Controllers;

[Route("api/settings")]
[ApiController]
public class AppSettingsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AppSettingsController(IConfiguration config)
    {
        _configuration = config;
    }

    [HttpGet]
    public IActionResult GetConfigurationSettings()
    {
        return Ok(_configuration.GetSection("AppConfiguration").GetChildren());
    }
}
