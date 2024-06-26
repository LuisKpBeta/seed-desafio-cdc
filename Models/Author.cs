using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

[Index(nameof(Email), IsUnique = true)]
public class Author
{
    [Key]
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Author(string name, string email, string description)
    {
        Name = name;
        Email = email;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}