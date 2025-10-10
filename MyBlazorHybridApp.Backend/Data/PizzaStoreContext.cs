using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Backend.Model;

namespace MyBlazorHybridApp.Backend.Data
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options) 
        { 
        
        }
        public DbSet<PizzaSpecial> Specials { get; set; } = null!;

    }
}
