using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Models
{
    [Table("contacts")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("mobile_phone")]
        public string? MobilePhone { get; set; }
        [Column("job_title")]
        public string? JobTitle { get; set; }
        [Column("birth_date",TypeName = "date")]
        public DateTime? BirthDate { get; set; }
    }
}
