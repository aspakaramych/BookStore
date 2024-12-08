namespace Book.Api.Contracts;

public record BookResponse(
    Guid id,
    string title,
    string description,
    string author,
    decimal amount,
    decimal price);