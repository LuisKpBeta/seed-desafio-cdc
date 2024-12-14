using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.DTO;

public class CreateState
{
  [Required]
  public string Name { get; set; } = string.Empty;
  [Required]
  public int CountryId { get; set; }
}