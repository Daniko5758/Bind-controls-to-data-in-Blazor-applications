using MyBlazorHybridApp.Backend.Model;

namespace MyBlazorHybridApp.Backend.Data
{
    public interface ISpecials
    {
        Task<IEnumerable<PizzaSpecial>> GetSpecials();

    }
}
