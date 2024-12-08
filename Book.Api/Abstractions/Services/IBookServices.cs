namespace Book.Api.Abstractions.Services;

public interface IBookServices
{
    Task<Guid> Create(Models.Book book);
    
    Task<Guid> Update(Guid id, string title, string description, string author, decimal amount, decimal price);
    
    Task<Guid> Delete(Guid id);

    Task<Models.Book> Get(Guid id);
    
    Task<List<Models.Book>> GetAll(); 
}