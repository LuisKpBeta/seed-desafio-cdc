using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.Controllers.DTO.Sales;

public class CreateOrderItemResponse
{
  [JsonPropertyName("idLivro")]
  public int BookId { get; set; }
  [JsonPropertyName("quantidade")]
  public uint Quantity { get; set; }

  public decimal Value { get; set; }
}