using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment2WebAPI.Persistance
{
    
        public class CloudContext: DbContext
        {
            //tables we can interact with - here it will be created
            public DbSet<Adult> Adults { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                
                optionsBuilder.UseSqlite(@"Data Source = Adulttable.db");
            }
            
         
        }
}