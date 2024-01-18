using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class OpeningTimeController : ControllerBase
{
    IOptions <OpeningTime> _openingTime;

    public OpeningTimeController(IOptions<OpeningTime> openingTime){
      _openingTime = openingTime;
    }

    [HttpGet("openingtime")]
    public IActionResult Get()
    {
      return Ok(_openingTime.Value);
    }
}
