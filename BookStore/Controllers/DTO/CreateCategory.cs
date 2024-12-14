using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.DTO;

public class CreateCategory
{
  [Required]
  public required string Name { get; set; }

}