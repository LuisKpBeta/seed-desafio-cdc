using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers.DTO;

public class CreateCountry
{
  [Required]
  public string Name { get; set; } = string.Empty;
}