using Book.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.DataAccess;

public class BookDbContext: DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options): base(options)
    {

    }
    
    public DbSet<BookEntity> Books { get; set; }
}