using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Models.Sales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    var exists = await _context.Cupon.AnyAsync(c => c.Code == payload.Code);
    if (exists)
    {
      var errorMessage = new { error = "The cupon code already exists" };
      return BadRequest(errorMessage);
    }
    var cupon = payload.ToModel();
    await _context.Cupon.AddAsync(cupon);
    await _context.SaveChangesAsync();
    return Ok(cupon);
  }
}