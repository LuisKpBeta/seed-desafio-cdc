using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class OrderItem
{
  [Required]
  public Book Item { get; set; }
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

  public OrderItem(Book book, uint quantity)
  {
    Quantity = quantity;
    Price = book.Price;
    Item = book;
  }
}
