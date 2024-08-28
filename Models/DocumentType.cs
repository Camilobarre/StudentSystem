using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models;

[Table("StudentSystem")]
public class DocumentType
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("name")]
    [MaxLength(50, ErrorMessage = "The Name field must be less than {50} characters.")]
    public required string Name { get; set; }

    [Column("last_name")]
    [MinLength(2, ErrorMessage = "The Abbreviation field must be at least {2} characters.")]
    [MaxLength(50, ErrorMessage = "The Abbreviation field must be at most {50} characters.")]
    public required string Abbreviation { get; set; }

    [Column("age")]
    [MaxLength(10, ErrorMessage = "The Name field must be at most {10} characters.")]
    public int Age { get; set; }

    [EmailAddress]
    [Column("email")]
    [MaxLength(50, ErrorMessage = "The Name field must be at most {50} characters.")]
    public string? Email { get; set; }

    [Phone]
    [Column("phone_number")]
    [MaxLength(50, ErrorMessage = "The Name field must be at most {50} characters.")]
    public string? PhoneNumber { get; set; }

    [Column("address")]
    [MaxLength(100, ErrorMessage = "The Name field must be at most {100} characters.")]
    public string? Address { get; set; }

    [Column("clan")]
    [MaxLength(50, ErrorMessage = "The Name field must be at most {50} characters.")]
    public string? Clan { get; set; }

    [Column("teacher")]
    [MaxLength(50, ErrorMessage = "The Name field must be at most {50} characters.")]
    public string? Teacher { get; set; }

    [Column("language")]
    [MaxLength(50, ErrorMessage = "The Name field must be at most {50} characters.")]
    public string? Language { get; set; }

    public DocumentType()
    {
        Id = Guid.NewGuid();
    }
}