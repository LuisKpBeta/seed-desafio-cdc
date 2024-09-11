using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

[Index(nameof(Name), IsUnique = true)]
public class Country
{
  [Key]
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = string.Empty;
  public virtual ICollection<State> States { get; set; }
  public Country(string name)
  {
    Name = name;
    States = [];
  }
}