using System.ComponentModel.DataAnnotations;


namespace BookStore.Controllers.DTO.Sales;

public class CreateOrderResponse
{
  public decimal Total { get; set; }
  public bool HasCupon { get; set; }
  public decimal? TotalWithCupon { get; set; } = null;
  public virtual ICollection<CreateOrderItemResponse> Itens { get; set; } = [];

  public CreateOrderResponse(int total, bool hasCupon, List<CreateOrderItemResponse> itens, int totalWithCupon = 0)
  {
    Total = (decimal)total / 100;
    HasCupon = hasCupon;
    Itens = itens;
    if (hasCupon)
    {
      TotalWithCupon = (decimal)totalWithCupon / 100;
    }
  }
}