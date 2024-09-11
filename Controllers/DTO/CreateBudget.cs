using System.ComponentModel.DataAnnotations;
using BookStore.Models;
using BookStore.Models.Sale;

namespace BookStore.Controllers.DTO;

public class CreateBudget
{
  [Required]
  [EmailAddress]
  public required string Email { get; set; }
  [Required]
  public required string Name { get; set; }
  [Required]
  public required string Surname { get; set; }
  private string _document = "";
  [Required]
  // adicionar parametro de tamanho
  public string Document
  {
    get => _document;
    set
    {
      if (value.Length != 11 && value.Length != 14)
      {
        throw new ArgumentException("Invalid document");
      }
      _document = value;
    }
  }
  [Required]
  public required string Address { get; set; }
  [Required]
  public required string Complement { get; set; }
  [Required]
  public required string City { get; set; }
  public required int CountryId { get; set; }
  public int? StateId { get; set; }
  public required string PhoneNumber { get; set; }
  public required string PostalCode { get; set; }

  public Budget ToModel(Country country, State? state)
  {
    return new Budget(
      email: Email,
      name: Name,
      surname: Surname,
      document: Document,
      address: Address,
      complement: Complement,
      city: City,
      country: country,
      state: state,
      phoneNumber: PhoneNumber,
      postalCode: PostalCode
    );
  }
}