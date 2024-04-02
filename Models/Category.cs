using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
  [Key]
  public int Id { get; private set; }

  public required string Name { get; set; }

}