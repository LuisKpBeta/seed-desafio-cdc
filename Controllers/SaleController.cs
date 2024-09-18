using BookStore.Controllers.DTO.Sales;
using BookStore.Models;
using BookStore.Models.Sales;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class SaleController : ControllerBase
{
  private readonly ILogger<SaleController> _logger;
  private readonly RegionService _regionService;
  private readonly BookService _bookService;

  public SaleController(ILogger<SaleController> logger, RegionService regionService, BookService bookService)
  {
    _logger = logger;
    _regionService = regionService;
    _bookService = bookService;
  }

  [Route("/Sale")]
  [HttpPost]
  public async Task<ActionResult<Sale>> CreateSale([FromBody] CreateSale payload)
  {
    int stateId = (int)(payload.StateId != null ? payload.StateId : 0);
    var (errorMessage, country) = await _regionService.FindCountyAndState(payload.CountryId, stateId);
    if (errorMessage is not null)
    {
      var message = new { error = errorMessage };
      return BadRequest(message);
    }
    State? stateInfo = null;
    if (country!.States.Count != 0)
    {
      stateInfo = country!.States.Where(s => s.Id == stateId).First();
    }

    List<int> booksId = payload.OrderData.Itens.Select(i => i.BookId).ToList();

    var (bookList, notFound) = await _bookService.GetBooksByIdList(booksId);
    if (notFound.Count != 0)
    {
      var message = new { error = $"Not found books with Id: {string.Join(",", notFound)}" };
      return BadRequest(message);
    };


    List<OrderItem> orderItens = payload.OrderData.Itens.Select(i =>
    {
      Book book = bookList.Find(b => b.Id == i.BookId)!;
      OrderItem orderItem = new OrderItem(book, i.Quantity);
      return orderItem;
    }).ToList();
    Order order = new Order(orderItens);
    if (order.Total != payload.OrderData.GetTotalParsed())
    {
      var message = new { error = $"order total value doesn't match with calculated value, expected {order.Total} but received {payload.OrderData.GetTotalParsed()}" };
      return BadRequest(message);
    }
    // verificar se o total de order é igual ao total do payload
    Sale sale = payload.ToModel(country, stateInfo, order);

    var response = CreateSaleResponse.FromModel(sale);
    return Created(nameof(Sale), response);
  }
}
