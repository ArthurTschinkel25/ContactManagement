using ContactProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControll.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
        public DbSet<ContactModel> Contacts { get; set; }
    }
}
