using System.Collections.Generic;
using System.Web.Http;
using PlanetDatabase.Models;
using PlanetDatabase.Repositories;

namespace PlanetDatabase.Controllers
{
    public class PlanetsController : ApiController
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetsController(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }
        
        public IEnumerable<Planet> GetPlanets()
        {
            return _planetRepository.GetAllPlanets();
        }
    }
}
