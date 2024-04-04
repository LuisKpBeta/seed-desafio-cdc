using System.Net;
using BookStore.Controllers.DTO;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers;

[ApiController]
[Route("Book")]
public class ReadBookController : ControllerBase
{
  private readonly ILogger<ReadBookController> _logger;
  private readonly BookStoreContext bookContext;

  public ReadBookController(ILogger<ReadBookController> logger, BookStoreContext context)
  {
    _logger = logger;
    bookContext = context;
  }
  [HttpGet]
  public ActionResult<List<BookPreview>> ListBooks()
  {
    return bookContext.Book.AsNoTracking().Select(b => new BookPreview { Id = b.Id, Title = b.Title }).ToList();
  }
  [HttpGet("{id}")]
  public ActionResult<Book> GetBook(int id)
  {
    Book? book = bookContext.Book
      .Include(b => b.AuthorData)
      .Include(b => b.CategoryInfo)
      .FirstOrDefault(b => b.Id == id);

    if (book is null)
    {
      return NotFound();
    }
    return Ok(book);
  }
}
