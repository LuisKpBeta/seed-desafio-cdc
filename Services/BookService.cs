using BookStore.Controllers.DTO;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class BookService
{
  private readonly BookStoreContext context;
  public BookService(BookStoreContext bookContext)
  {
    context = bookContext;
  }
  public async Task<(string?, Book?)> ValidateNewBook(CreateBook newBookData)
  {
    var dataExists = await context.Book.AnyAsync(b => b.Title == newBookData.Title || b.Isbn == newBookData.Isbn);
    if (dataExists)
    {
      return ("The title or ISBN already exists", null);
    }

    Author? author = await context.Author.FindAsync(newBookData.AuthorId);
    if (author is null)
    {
      return ("The Author not registered", null);
    }
    Category? category = await context.Category.FindAsync(newBookData.CategoryId);
    if (category is null)
    {
      return ("The Category not registered", null);
    }
    Book newBook = new()
    {
      Title = newBookData.Title,
      Resume = newBookData.Resume,
      Summary = newBookData.Summary,
      Price = newBookData.Price,
      Pages = newBookData.Pages,
      Isbn = newBookData.Isbn,
      PublishDate = newBookData.PublishDate,
      CategoryInfo = category,
      AuthorData = author,
    };
    return (null, newBook);
  }
  public async Task<Book> Save(Book book)
  {
    context.Add(book);
    await context.SaveChangesAsync();
    return book;
  }

}