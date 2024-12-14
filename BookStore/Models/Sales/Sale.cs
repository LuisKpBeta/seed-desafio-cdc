using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class Sale
{
  [Key]
  public int Id { get; set; }

  [EmailAddress]
  public required string Email { get; set; }
  public required string Name { get; set; }
  public required string Surname { get; set; }
  public required string Document { get; set; }
  public required string Address { get; set; }
  public required string Complement { get; set; }
  public required string City { get; set; }
  public required Country CountryInfo { get; set; }
  public required State? StateInfo { get; set; }
  public required string PhoneNumber { get; set; }
  public required string PostalCode { get; set; }
  public required Order SaleOrder { get; set; }
  public static Sale CreateSale(string email, string name, string surname, string document, string address, string complement, string city, Country country, State? state, string phoneNumber, string postalCode, Order order)
  {
    return new Sale
    {
      Email = email,
      Name = name,
      Surname = surname,
      Document = document,
      Address = address,
      Complement = complement,
      City = city,
      CountryInfo = country,
      StateInfo = state,
      PhoneNumber = phoneNumber,
      PostalCode = postalCode,
      SaleOrder = order,
    };
  }
}