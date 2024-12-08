using Book.Api.Abstractions.Services;
using Book.Api.DataAccess;
using Book.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Services;

public class BookServices: IBookServices
{
    private readonly BookDbContext _context;

    public BookServices(BookDbContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> Create(Models.Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Author = book.Author,
            Amount = book.Amount,
            Price = book.Price
        };
        
        await _context.AddAsync(bookEntity);
        await _context.SaveChangesAsync();
        return bookEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, string author, decimal amount, decimal price)
    {
        await _context.Books.Where(b => b.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(b => b.Title, b => title)
            .SetProperty(b => b.Description, b => description)
            .SetProperty(b => b.Author, b => author)
            .SetProperty(b => b.Amount, b => amount)
            .SetProperty(b => b.Price, b => price));
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
        return id;
    }

    public async Task<Models.Book> Get(Guid id)
    {
        var bookEntity = await _context.Books.FindAsync(id);
        var book = Models.Book.Create(bookEntity.Id, bookEntity.Title, bookEntity.Description, bookEntity.Author,
            bookEntity.Amount, bookEntity.Price);
        return book;
    }

    public async Task<List<Models.Book>> GetAll()
    {
        var bookEntities = await _context.Books.AsNoTracking().ToListAsync();
        var books = bookEntities.Select(b =>
            Models.Book.Create(b.Id, b.Title, b.Description, b.Author, b.Amount, b.Price)).ToList();
        return books;
    }
}