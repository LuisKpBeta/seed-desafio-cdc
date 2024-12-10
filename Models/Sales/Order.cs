using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class Order
{
  [Key]
  public int Id { get; set; }
  [Required]
  public int Total { get; set; }
  public int FinalValue { get; set; }
  public string CuponCode { get; private set; } = "";
  public ICollection<OrderItem> Items { get; set; }
  private Order()
  {
    Items = [];
  }
  public Order(ICollection<OrderItem> items)
  {
    Items = items;
    Total = items.Aggregate(0, (acc, i) => acc + (i.Price * (int)i.Quantity));
  }
  public void ApplyCupon(Cupon cupon)
  {
    CuponCode = cupon.Code;

    double discount = (double)cupon.Percentage / 100.00;
    FinalValue = (int)(Total - (Total * discount));
  }

}