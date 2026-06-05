namespace Contacts.Models.DTO
{
    public record ContactResponseDto(
        int Id,
        string Name,
        string? MobilePhone,
        string? JobTitle,
        DateOnly? BirthDate
    );
}
