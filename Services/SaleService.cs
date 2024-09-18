using BookStore.Models;
using BookStore.Models.Sales;

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
}