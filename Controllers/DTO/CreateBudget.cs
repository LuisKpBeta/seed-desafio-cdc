using System.ComponentModel.DataAnnotations;
using BookStore.Controllers.Annotations;
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
  [Required]
  [DocumentAttribute]
  // adicionar parametro de tamanho
  public required string Document { get; set; }
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