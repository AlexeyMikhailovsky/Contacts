using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(150, ErrorMessage = "Name length no longer than 150")]
        public string Name { get; set; } = string.Empty;
        [Phone(ErrorMessage = "Incorrect phone format")]
        public string? MobilePhone { get; set; }
        [StringLength(100)]
        public string? JobTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
