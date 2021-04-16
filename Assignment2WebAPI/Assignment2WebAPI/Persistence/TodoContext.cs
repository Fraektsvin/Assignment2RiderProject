using Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment2WebAPI.Persistence
{
    public class TodoContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }
    }
}