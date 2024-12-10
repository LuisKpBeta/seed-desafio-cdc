using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Models.Sales;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;
[ApiController]
[Route("[controller]")]
public class CuponController : ControllerBase
{
  private readonly ILogger<CuponController> _logger;
  private readonly BookStoreContext _context;

  public CuponController(ILogger<CuponController> logger, BookStoreContext context)
  {
    _logger = logger;
    _context = context;
  }

  [Route("/Cupon")]
  [HttpPost]
  public async Task<ActionResult<Cupon>> CreateCupon([FromBody] CreateCupon payload)
  {
    var cupon = payload.ToModel();
    await _context.Cupon.AddAsync(cupon);
    await _context.SaveChangesAsync();
    return cupon;
  }
}