using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Api.DataAccess.Entities;

[Table("Books")]
public class BookEntity
{
    [Key]
    [Column("Id")]
    public Guid Id { get; set; }
    
    [Column("Title")]
    [Required]
    public string Title { get; set; } = String.Empty;
    
    [Column("Description")]
    [Required]
    public string Description { get; set; } = String.Empty;
    
    [Column("Author")]
    [Required]
    public string Author { get; set; } = String.Empty;
    
    [Column("Amount")]
    [Required]
    public decimal Amount { get; set; }
    
    [Column("Price")]
    [Required]
    public decimal Price { get; set; }
}