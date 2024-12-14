using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("/")]
public class CountryController : ControllerBase
{
  private readonly ILogger<CountryController> _logger;
  private readonly RegionService _service;
  public CountryController(ILogger<CountryController> logger, RegionService regionService)
  {
    _logger = logger;
    _service = regionService;
  }
  [Route("/Country")]
  [HttpPost]
  public async Task<ActionResult<Country>> CreateCountry([FromBody] CreateCountry payload)
  {
    var result = await _service.CreateCountry(payload.Name);
    if (result.Item1 is not null)
    {
      var errorMessage = new { error = result.Item1 };
      return BadRequest(errorMessage);
    }
    return Created(nameof(Country), result.Item2);
  }
  [Route("/State")]
  [HttpPost]
  public async Task<ActionResult<State>> CreateState([FromBody] CreateState payload)
  {
    var result = await _service.CreateState(payload.Name, payload.CountryId);
    if (result.Item1 is not null)
    {
      var errorMessage = new { error = result.Item1 };
      return BadRequest(errorMessage);
    }
    return Created(nameof(State), result.Item2);
  }
}