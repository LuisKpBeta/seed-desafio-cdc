
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

[Index(nameof(Name), IsUnique = true)]
public class State
{
  [Key]
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = string.Empty;

  [Required]
  public virtual required Country Country { get; set; }
}