using Contacts.Models.DTO;
using Contacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactResponseDto>>> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id:int}")] 
        public async Task<ActionResult<ContactResponseDto>> GetById(int id)
        {
            if (id <= 0) return BadRequest("Неверный Id");
            var contact = await _contactService.GetByIdAsync(id);
            return contact is null ? NotFound() : Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactResponseDto>> Create(ContactCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _contactService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ContactUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id <= 0) return BadRequest("Неверный Id");
            var result = await _contactService.UpdateAsync(id, dto);
            return result is null ? NotFound() : NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Неверный Id");
            var deleted = await _contactService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
