using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Sales;

public class Sale
{
  [Key]
  public int Id { get; set; }

  [EmailAddress]
  public string Email { get; private set; }
  public string Name { get; private set; }
  public string Surname { get; private set; }
  public string Document { get; private set; }
  public string Address { get; private set; }
  public string Complement { get; private set; }
  public string City { get; private set; }
  public Country CountryInfo { get; private set; }
  public State? StateInfo { get; private set; }
  public string PhoneNumber { get; private set; }
  public string PostalCode { get; private set; }

  public Order SaleOrder { get; set; }
  public Sale(string email, string name, string surname, string document, string address, string complement, string city, Country country, State? state, string phoneNumber, string postalCode, Order order)
  {
    Email = email;
    Name = name;
    Surname = surname;
    Document = document;
    Address = address;
    Complement = complement;
    City = city;
    CountryInfo = country;
    StateInfo = state;
    PhoneNumber = phoneNumber;
    PostalCode = postalCode;
    SaleOrder = order;
  }
}