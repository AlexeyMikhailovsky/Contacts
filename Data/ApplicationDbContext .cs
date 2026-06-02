using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Contacts.Models.Contact> Contacts { get; set; }
    }
}
    