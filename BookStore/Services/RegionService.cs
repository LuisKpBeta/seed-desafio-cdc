using BookStore.Controllers.DTO;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class RegionService
{
  private readonly BookStoreContext _context;

  public RegionService(BookStoreContext c)
  {
    _context = c;
  }
  public async Task<(string?, Country?)> CreateCountry(string name)
  {
    bool alreadyExists = await _context.Country.AnyAsync(c => c.Name == name);
    if (alreadyExists)
    {
      return ("this country already registered", null);
    }
    Country newCountry = new(name);
    _context.Country.Add(newCountry);
    await _context.SaveChangesAsync();
    return (null, newCountry);
  }
  public async Task<(string?, State?)> CreateState(string name, int countryId)
  {
    Country? country = await _context.Country.FindAsync(countryId);
    if (country is null)
    {
      return ("this country aren't registered", null);
    }
    bool exists = await _context.State.AnyAsync(b => b.Name == name);
    if (exists)
    {
      return ("this state already registered", null);
    }
    State newState = new State
    {
      Name = name,
      Country = country!
    };
    _context.State.Add(newState);
    await _context.SaveChangesAsync();
    return (null, newState);
  }
  public async Task<(string?, Country?)> FindCountyAndState(int countryId, int stateId)
  {
    Country? country = await _context.Country
      .Include(c => c.States.Where(s => s.Id == stateId))
      .FirstOrDefaultAsync(c => c.Id == countryId);
    if (country is null)
    {
      return ("this country aren't registered", null);
    }
    if (country.States.Count == 0 && stateId == 0)
    {
      bool hasStates = await _context.State.AnyAsync(s => s.Country == country);
      if (hasStates)
      {
        return ("state cannot be null", null);
      }
    }
    if (country.States.Count == 0 && stateId != 0)
    {
      return ("this state aren't registered", null);
    }

    return (null, country);
  }
}