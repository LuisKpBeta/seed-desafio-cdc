using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class Cupon
{
  [Key]
  public int Id { get; set; }
  public required string Code { get; set; }
  public uint Percentage { get; set; }
  public DateOnly ExpiresAt { get; set; }
}