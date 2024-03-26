using System.Net;
using BookStore.Controllers.DTO;
using BookStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly BookStoreContext _context;

    public AuthorController(ILogger<AuthorController> logger, BookStoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor([FromBody] CreateAuthor payload)
    {
        var emailExists = await _context.Author.AnyAsync(a => a.Email == payload.Email);
        if (emailExists)
        {
            var errorMessage = new { error = "The email already exists" };
            return BadRequest(errorMessage);
        }


        var author = new Author(payload.Name, payload.Email, payload.Description);
        _context.Add(author);
        await _context.SaveChangesAsync();
        return Created(nameof(Author), author);
    }
}
