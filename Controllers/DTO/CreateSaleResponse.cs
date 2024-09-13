using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BookStore.Models;
using BookStore.Models.Sale;

namespace BookStore.Controllers.DTO;

public class CreateSaleResponse
{
  public int Id { get; set; }
  public required string Email { get; set; }
  public required string Name { get; set; }
  public required string Surname { get; set; }
  // adicionar parametro de tamanho
  public required string Document { get; set; }
  public required string Address { get; set; }
  public required string Complement { get; set; }
  public required string City { get; set; }
  public required string CountryName { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? StateName { get; set; }
  public required string PhoneNumber { get; set; }
  public required string PostalCode { get; set; }

  public static CreateSaleResponse FromModel(Sale sale)
  {
    return new CreateSaleResponse
    {
      Id = sale.Id,
      Email = sale.Email,
      Name = sale.Name,
      Surname = sale.Surname,
      Document = sale.Document,
      Address = sale.Address,
      Complement = sale.Complement,
      City = sale.City,
      CountryName = sale.CountryInfo.Name,
      StateName = sale.StateInfo?.Name,
      PhoneNumber = sale.PhoneNumber,
      PostalCode = sale.PostalCode,
    };
  }
}