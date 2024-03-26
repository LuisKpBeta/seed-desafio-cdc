using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Category
{
  [Key]
  public int Id { get; private set; }

  public required string Name { get; set; }

}