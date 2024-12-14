using System.ComponentModel.DataAnnotations;
using BookStore.Models;

namespace BookStore.Controllers.DTO;

public class CreateBook
{
  [Required]
  public required string Title { get; set; }
  [Required]
  [MaxLength(500)]
  public required string Resume { get; set; }
  [Required]
  public required string Summary { get; set; }
  [Required]
  [Range(20, int.MaxValue)]
  public int Price { get; set; }
  [Required]
  [Range(100, int.MaxValue)]
  public int Pages { get; set; }
  [Required]
  public required string Isbn { get; set; }
  [Required]
  public DateOnly PublishDate { get; set; }
  [Required]
  public required int CategoryId { get; set; }
  [Required]
  public required int AuthorId { get; set; }
}





