using System.ComponentModel.DataAnnotations;


namespace BookStore.Controllers.DTO.Sales;

public class CreateOrderResponse
{
  public decimal Total { get; set; }
  public virtual ICollection<CreateOrderItemResponse> Itens { get; set; } = [];
}