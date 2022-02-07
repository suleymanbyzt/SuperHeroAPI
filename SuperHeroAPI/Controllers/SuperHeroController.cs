using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name ="Spider Man",
                    FirstName ="Peter",
                    LastName ="Parker",
                    Place="New York City"
                },
                new SuperHero {
                    Id = 2,
                    Name ="Ironman",
                    FirstName ="Tony",
                    LastName ="Stark",
                    Place="Long Island"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var superHero = heroes.Find(h => h.Id == id);
            if (superHero == null)
            {
                return BadRequest("Hero not found.");
            }
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero)
        {
            heroes.Add(superHero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var superHero = heroes.Find(h=>h.Id == request.Id);
            if (superHero == null)
            {
                return BadRequest("Hero not found.");
            }
            superHero.Name = request.Name;
            superHero.FirstName = request.FirstName;
            superHero.LastName = request.LastName;
            superHero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var superHero = heroes.Find(h=>h.Id== id);
            if (superHero == null)
            {
                return BadRequest("Hero not found.");
            }
            else
            {
                heroes.Remove(superHero);
                return Ok ($"Success");
            }
            
            return Ok(heroes);
        }
    }
}
