using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Backend.Model;

namespace MyBlazorHybridApp.Backend.Data
{
    public class SpecialsData : ISpecials
    {

       private readonly PizzaStoreContext _context;
       
        public SpecialsData(PizzaStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PizzaSpecial>> GetSpecials()
        {
            // 1. Ambil semua data dari database terlebih dahulu
            var specials = await _context.Specials.ToListAsync();

            // 2. Urutkan datanya di memori aplikasi setelah diterima
            return specials.OrderByDescending(s => s.BasePrice);
        }
    }
}
