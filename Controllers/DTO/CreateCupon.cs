using System.ComponentModel.DataAnnotations;
using BookStore.Models.Sales;

namespace BookStore.Controllers.DTO;

public class CreateCupon
{
  [Required]
  public string Code { get; set; } = string.Empty;
  [Required]
  public uint Percentage { get; set; }

  public DateOnly ExpiresAt { get; set; }

  public Cupon ToModel()
  {
    return new Cupon
    {
      Code = Code,
      Percentage = Percentage,
      ExpiresAt = ExpiresAt
    };
  }
}