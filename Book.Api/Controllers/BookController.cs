using Book.Api.Abstractions.Services;
using Book.Api.Contracts;
using Book.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Book.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController: ControllerBase
{
    private readonly IBookServices _services;

    public BookController(IBookServices services)
    {
        _services = services;
    }
    
    [HttpGet("/get")]
    public async Task<ActionResult<List<BookResponse>>> GetAll()
    {
        var books = await _services.GetAll();
        var response = books.Select(b => new BookResponse(b.Id, b.Title, b.Description, b.Author, b.Amount, b.Price));
        return Ok(response);
    }
    
    [HttpPost("/get")]
    public async Task<ActionResult<Guid>> GetBook(Guid id)
    {
        var book = await _services.Get(id);
        var response = new BookResponse(book.Id, book.Title, book.Description, book.Author, book.Amount, book.Price);
        return Ok(response);
    }
    
    [HttpPost("/create")]
    public async Task<ActionResult<Guid>> Create([FromBody] BookRequest request)
    {
        var book = Models.Book.Create(
            Guid.NewGuid(),
            request.title,
            request.description,
            request.author,
            request.amount,
            request.price);
        var bookId = await _services.Create(book);
        return Ok(bookId);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] BookRequest request)
    {
        var bookId = await _services.Update(id, request.title, request.description, request.author, request.amount, request.price);
        return Ok(bookId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> Delete(Guid id)
    {
        var bookId = await _services.Delete(id);
        return Ok(bookId);
    }
}