using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class Order
{
  [Key]
  public int Id { get; set; }
  [Required]
  public int Total { get; set; }
  public virtual ICollection<OrderItem> Items { get; set; } = [];

  public Order(ICollection<OrderItem> items)
  {
    Items = items;
    Total = items.Aggregate(0, (acc, i) => acc + (i.Price * (int)i.Quantity));
  }
}