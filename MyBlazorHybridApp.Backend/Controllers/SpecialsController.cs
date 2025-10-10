using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Backend.Data;
using MyBlazorHybridApp.Backend.Model;

namespace MyBlazorHybridApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsController : ControllerBase
    {
        private readonly ISpecials _specials;

        public SpecialsController(ISpecials specials)
        {
            _specials = specials;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {   
            var specials = await _specials.GetSpecials();
            return Ok(specials);

        }
    }
}
