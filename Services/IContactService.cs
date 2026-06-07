using Contacts.Models.DTO;

namespace Contacts.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponseDto>> GetAllAsync();
        Task<ContactResponseDto?> GetByIdAsync(int id);
        Task<ContactResponseDto> CreateAsync(ContactCreateDto dto);
        Task<ContactResponseDto?> UpdateAsync(int id, ContactUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
