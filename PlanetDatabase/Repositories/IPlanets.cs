using System.Collections.Generic;
using PlanetDatabase.Models;

namespace PlanetDatabase.Repositories
{
    public interface IPlanetRepository
    {
        IEnumerable<Planet> GetAllPlanets();
    }

    public class PlanetRepository: IPlanetRepository
    {
        private readonly Planet[] _planets =
        {
            new Planet {Name = "Mercury", DistanceToSun = 57910000},
            new Planet {Name = "Venus", DistanceToSun = 108200000},
            new Planet {Name = "Earth", DistanceToSun = 149600000},
            new Planet {Name = "Mars", DistanceToSun = 227900000},
            new Planet {Name = "Jupiter", DistanceToSun = 778500000},
            new Planet {Name = "Saturn", DistanceToSun = 1433000000},
            new Planet {Name = "Uranus", DistanceToSun = 2871000000},
            new Planet {Name = "Neptune", DistanceToSun = 4495000000}
        };

        public IEnumerable<Planet> GetAllPlanets()
        {
            return _planets;
        }
    }
}
