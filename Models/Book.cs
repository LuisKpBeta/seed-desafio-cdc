using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;
[Index(nameof(Title), IsUnique = true)]
[Index(nameof(Isbn), IsUnique = true)]
public class Book
{
  [Key]
  public int Id { get; set; }
  public required string Title { get; set; }
  public required string Resume { get; set; }
  public required string Summary { get; set; }
  public int Price { get; set; }
  public int Pages { get; set; }
  public required string Isbn { get; set; }
  public DateOnly PublishDate { get; set; }
  public required Category CategoryInfo { get; set; }
  public required Author AuthorData { get; set; }

}