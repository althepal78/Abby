using Abbyweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Abbyweb.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Category>Category { get; set; }
    }
}
