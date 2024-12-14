using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.DTO;

public class CreateAuthor
{
  [Required]
  public required string Name { get; set; }
  [Required]
  [EmailAddress]
  public required string Email { get; set; }
  [Required]
  [MaxLength(400)]
  public required string Description { get; set; }
}