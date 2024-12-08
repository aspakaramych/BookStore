namespace Book.Api.Contracts;

public record BookRequest(
    string title,
    string description,
    string author,
    decimal amount,
    decimal price);