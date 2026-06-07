using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.DTO
{
    public record ContactUpdateDto(
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        string Name,
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "10–15 цифр, может начинаться с +")]
        string? MobilePhone,
        [StringLength(100, ErrorMessage = "Максимум 100 символов")]
        string? JobTitle,
        DateOnly? BirthDate
    );
}
