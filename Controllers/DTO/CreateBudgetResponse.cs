using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BookStore.Models;
using BookStore.Models.Sale;

namespace BookStore.Controllers.DTO;

public class CreateBudgetResponse
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

  public static CreateBudgetResponse FromModel(Budget budget)
  {
    return new CreateBudgetResponse
    {
      Id = budget.Id,
      Email = budget.Email,
      Name = budget.Name,
      Surname = budget.Surname,
      Document = budget.Document,
      Address = budget.Address,
      Complement = budget.Complement,
      City = budget.City,
      CountryName = budget.CountryInfo.Name,
      StateName = budget.StateInfo?.Name,
      PhoneNumber = budget.PhoneNumber,
      PostalCode = budget.PostalCode,
    };
  }
}