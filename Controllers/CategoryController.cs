using System.Net;
using BookStore.Controllers.DTO;
using BookStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly BookStoreContext _context;

    public CategoryController(ILogger<CategoryController> logger, BookStoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateCategory([FromBody] CreateCategory payload)
    {
        var nameExists = await _context.Category.AnyAsync(a => a.Name == payload.Name);
        if (nameExists)
        {
            var errorMessage = new { error = "The category already exists" };
            return BadRequest(errorMessage);
        }


        Category category = new()
        {
            Name = payload.Name
        };
        _context.Add(category);
        await _context.SaveChangesAsync();
        return Created(nameof(Category), category);
    }
}
