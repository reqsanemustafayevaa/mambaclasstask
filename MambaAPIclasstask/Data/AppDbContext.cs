using MambaAPIclasstask.Entities;
using Microsoft.EntityFrameworkCore;

namespace MambaAPIclasstask.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Memberprofession> memberprofessions { get; set; }

    }
}
