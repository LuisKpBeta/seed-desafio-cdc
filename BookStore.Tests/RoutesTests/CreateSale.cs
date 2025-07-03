using BookStore.Tests.Setup;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using BookStore.Models;
using BookStore.Controllers.DTO;
namespace BookStore.Tests.RoutesTests;

[Collection("Test Collection")]
public class GetBooksTest
{
    private readonly HttpClient _client;
    private readonly IntegrationTestFactory<Program> _factory;
    public GetBooksTest(IntegrationTestFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _factory = factory;
    }
    private Book CreateBook()
    {
        var newBook = new Book
        {
            Title = "Livro de Teste",
            Resume = "Resumo do Livro de Teste",
            Summary = "Sumário do Livro de Teste",
            Price = 10000, // Preço em centavos
            Pages = 200,
            Isbn = "123-4567890123",
            PublishDate = new DateOnly(2023, 10, 1),
            CategoryInfo = new Category { Name = "Categoria Teste" },
            AuthorData = new Author("Autor Teste", "autor@autor.com", "")
        };

        using (var scope = _factory.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<BookStoreContext>();

            context.Book.Add(newBook);
            context.SaveChanges();
        }
        return newBook;

    }

    [Fact]
    public async Task GetBooksShouldReturnOkAndListOfBooks()
    {
        // Arrange: Inserir dados no banco de testes

        // Act: Fazer a chamada HTTP para a API
        CreateBook();
        var response = await _client.GetAsync("/book");
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var books = JsonSerializer.Deserialize<List<BookPreview>>(
            content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        Assert.NotNull(books);
        Assert.Single(books);
        Assert.Equal("Livro de Teste", books[0].Title);

        // DTO auxiliar para deserialização
    }
        [Fact]
    public async Task GetBooksByIdShouldReturnOkAndOneSingleBook()
    {
        // Arrange: Inserir dados no banco de testes
       
        // Act: Fazer a chamada HTTP para a API
        var book = CreateBook();
        var response = await _client.GetAsync($"/book/{book.Id}");
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        var responseBook = JsonSerializer.Deserialize<BookPreview>(
            content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        Assert.Equal(book.Id, responseBook.Id);
        Assert.Equal("Livro de Teste", responseBook.Title);

        // DTO auxiliar para deserialização
    }
}