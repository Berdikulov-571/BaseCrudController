using ApiTutorials.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace ApiTutorials.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
