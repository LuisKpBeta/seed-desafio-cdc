using System.ComponentModel.DataAnnotations;


namespace BookStore.Controllers.DTO.Sales;

public class CreateOrder
{
  [Required]
  [Range(1, double.MaxValue)]
  public double Total { get; set; }
  [MinLength(1)]
  public virtual ICollection<CreateOrderItem> Itens { get; set; } = [];

  public int GetTotalParsed()
  {
    return (int)(Total * 100);
  }
}

