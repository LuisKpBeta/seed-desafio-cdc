using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class OrderItem
{
  [Key]
  public int Id { get; set; }
  [Required]
  public required Book Item { get; set; }
  [Required]
  public uint Quantity { get; set; }
  private int _price;
  public int Price
  {
    get => _price;
    set
    {
      ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
      _price = value;
    }
  }


}
