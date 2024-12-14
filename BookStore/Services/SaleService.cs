using BookStore.Models;
using BookStore.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class SaleService
{
  private readonly BookStoreContext context;
  public SaleService(BookStoreContext bookContext)
  {
    context = bookContext;
  }

  public async Task<Sale> Save(Sale sale)
  {
    context.Add(sale);
    await context.SaveChangesAsync();
    return sale;
  }
  public async Task<Cupon?> FindCuponByCode(string code)
  {
    return await context.Cupon.FirstOrDefaultAsync(c => c.Code == code);
  }
}