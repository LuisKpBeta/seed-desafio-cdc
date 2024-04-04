using System.Net;
using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
  private readonly ILogger<BookController> _logger;
  private readonly BookService bookService;

  public BookController(ILogger<BookController> logger, BookService service)
  {
    _logger = logger;
    bookService = service;
  }

  [HttpPost]
  public async Task<ActionResult<Book>> CreateBook([FromBody] CreateBook payload)
  {
    var result = await bookService.ValidateNewBook(payload);
    if (result.Item1 is not null)
    {
      var errorMessage = new { error = result.Item1 };
      return BadRequest(errorMessage);
    }
    Book newBook = await bookService.Save(result.Item2!);
    return Created(nameof(Book), newBook);
  }

}
