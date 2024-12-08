using Book.Api.Abstractions.Services;
using Book.Api.DataAccess;
using Book.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookDbContext)));
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<IBookServices, BookServices>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();