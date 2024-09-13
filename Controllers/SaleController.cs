using System.Reflection.Metadata;
using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Models.Sale;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class SaleController : ControllerBase
{
  private readonly ILogger<SaleController> _logger;
  private readonly RegionService _regionService;

  public SaleController(ILogger<SaleController> logger, RegionService regionService)
  {
    _logger = logger;
    _regionService = regionService;
  }

  [Route("/Sale")]
  [HttpPost]
  public async Task<ActionResult<Sale>> CreateSale([FromBody] CreateSale payload)
  {
    int stateId = (int)(payload.StateId != null ? payload.StateId : 0);
    var (errorMessage, country) = await _regionService.FindCountyAndState(payload.CountryId, stateId);
    if (errorMessage is not null)
    {
      var message = new { error = errorMessage };
      return BadRequest(message);
    }


    var stateInfo = country!.States.FirstOrDefault<State>();
    Sale sale = payload.ToModel(country, stateInfo);
    var response = CreateSaleResponse.FromModel(sale);
    return Created(nameof(Sale), response);
  }
}
