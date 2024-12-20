using BookStore.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models;

public class BookStoreContext : DbContext
{
  public BookStoreContext(DbContextOptions<BookStoreContext> options)
      : base(options)
  {
  }

  public DbSet<Author> Author { get; set; } = null!;
  public DbSet<Category> Category { get; set; } = null!;
  public DbSet<Book> Book { get; set; } = null!;
  public DbSet<State> State { get; set; } = null!;
  public DbSet<Country> Country { get; set; } = null!;
  public DbSet<Sale> Sale { get; set; } = null!;
  public DbSet<Order> Order { get; set; } = null!;
  public DbSet<OrderItem> OrderItem { get; set; } = null!;
  public DbSet<Cupon> Cupon { get; set; } = null!;

}