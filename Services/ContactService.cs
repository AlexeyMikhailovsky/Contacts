using Contacts.Data;
using Contacts.Models;
using Contacts.Models.DTO;
using Microsoft.EntityFrameworkCore;

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
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactService> _logger;

        public ContactService(ApplicationDbContext context, ILogger<ContactService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ContactResponseDto>> GetAllAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return contacts.Select(c => MapToDto(c));
        }

        public async Task<ContactResponseDto?> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            return contact is null ? null : MapToDto(contact);
        }

        public async Task<ContactResponseDto> CreateAsync(ContactCreateDto dto)
        {
            var contact = new Contact
            {
                Name = dto.Name,
                MobilePhone = dto.MobilePhone,
                JobTitle = dto.JobTitle,
                BirthDate = dto.BirthDate?.ToDateTime(TimeOnly.MinValue)
            };
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Created contact {Id}: {Name}", contact.Id, contact.Name);
            return MapToDto(contact);
        }

        public async Task<ContactResponseDto?> UpdateAsync(int id, ContactUpdateDto dto)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null) return null;

            contact.Name = dto.Name;
            contact.MobilePhone = dto.MobilePhone;
            contact.JobTitle = dto.JobTitle;
            contact.BirthDate = dto.BirthDate?.ToDateTime(TimeOnly.MinValue);

            await _context.SaveChangesAsync();
            _logger.LogInformation("Updated contact {Id}", id);
            return MapToDto(contact);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null) return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Deleted contact {Id}", id);
            return true;
        }

        private static ContactResponseDto MapToDto(Contact c) => new(
            c.Id,
            c.Name,
            c.MobilePhone,
            c.JobTitle,
            c.BirthDate.HasValue ? DateOnly.FromDateTime(c.BirthDate.Value) : null
        );
    }
}
