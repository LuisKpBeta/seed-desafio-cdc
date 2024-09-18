using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookStore.Controllers.DTO.Sales;

public class CreateOrderItem
{
  [JsonPropertyName("idLivro")]
  public required int BookId { get; set; }
  [Range(1, int.MaxValue)]
  [JsonPropertyName("quantidade")]
  public required uint Quantity { get; set; }
}