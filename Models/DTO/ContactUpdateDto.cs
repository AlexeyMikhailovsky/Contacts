namespace Contacts.Models.DTO
{
    public record ContactUpdateDto(
        string Name,
        string? MobilePhone,
        string? JobTitle,
        DateOnly? BirthDate
    );
}
