using System.Net;
using BookStore.Controllers.DTO;
using BookStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
  private readonly ILogger<BookController> _logger;
  private readonly BookStoreContext _context;

  public BookController(ILogger<BookController> logger, BookStoreContext context)
  {
    _logger = logger;
    _context = context;
  }

  [HttpPost]
  public async Task<ActionResult<Author>> CreateBook([FromBody] CreateBook payload)
  {
    // titulo e ISBN são unicos
    var dataExists = await _context.Book.AnyAsync(b => b.Title == payload.Title || b.Isbn == payload.Isbn);
    if (dataExists)
    {
      var errorMessage = new { error = "The title or ISBN already exists" };
      return BadRequest(errorMessage);
    }

    Author? author = await _context.Author.FindAsync(payload.AuthorId);
    if (author is null)
    {
      var errorMessage = new { error = "The Author not registered" };
      return BadRequest(errorMessage);
    }
    Category? category = await _context.Category.FindAsync(payload.CategoryId);
    if (category is null)
    {
      var errorMessage = new { error = "The Category not registered" };
      return BadRequest(errorMessage);
    }


    Book newBook = new()
    {
      Title = payload.Title,
      Resume = payload.Resume,
      Summary = payload.Summary,
      Price = payload.Price,
      Pages = payload.Pages,
      Isbn = payload.Isbn,
      PublishDate = payload.PublishDate,
      CategoryInfo = category,
      AuthorData = author,
    };
    _context.Add(newBook);
    await _context.SaveChangesAsync();
    return Created(nameof(Book), newBook);
  }
}
