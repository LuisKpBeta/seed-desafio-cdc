using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using BookStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreContext>(opt =>
    opt.UseNpgsql("Host=localhost;Database=bookstore;Username=postgres;Password=postgres"));


builder.Services.AddControllers();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<RegionService>();
builder.Services.AddScoped<SaleService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
