namespace Book.Api.Models;

public class Book
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;

    public string Author { get; set; } = String.Empty;
    
    public decimal Amount { get; set; }
    
    public decimal Price { get; set; }

    private Book(Guid id, string title, string description, string author, decimal amount, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Author = author;
        Amount = amount;
        Price = price;
    }

    public static Book Create(Guid id, string title, string description, string author, decimal amount, decimal price)
    {
        var book = new Book(id, title, description, author, amount, price);
        return book;
    }
}