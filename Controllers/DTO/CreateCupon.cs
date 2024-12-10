using System.ComponentModel.DataAnnotations;
using BookStore.Controllers.Annotations;
using BookStore.Models.Sales;

namespace BookStore.Controllers.DTO;

public class CreateCupon
{
  [Required]
  public string Code { get; set; } = string.Empty;

  [Required]
  [Range(1, 100)]
  public uint Percentage { get; set; }

  [CuponDateAttribute]
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