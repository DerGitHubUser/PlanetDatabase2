using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlanetDatabase.Controllers;
using PlanetDatabase.Models;
using PlanetDatabase.Repositories;

namespace PlanetDatabase.Api.Test
{
    [TestClass]
    public class When_Requesting_All_Planets
    {

        [TestMethod]
        public void Then_All_Planets_Are_Returned()
        {
            //Arrange

            const string testplanetA = "TestPlanetA";
            const string testplanetB = "TestPlanetB";

            const int testplanetDistanceA = 5;
            const int testplanetDistanceB = 15;

            IEnumerable<Planet> testPlanets = new[]
            {
                new Planet
                {
                    Name = testplanetA,
                    DistanceToSun = testplanetDistanceA
                },
                new Planet
                {
                    Name = testplanetB,
                    DistanceToSun = testplanetDistanceB
                }
            };

            const int expectedPlanetCount = 2;

            var mockPlanetRepo = new Mock<IPlanetRepository>();
            mockPlanetRepo.Setup(x => x.GetAllPlanets()).Returns(testPlanets);

            var controller = new PlanetsController(mockPlanetRepo.Object);

            // Act
            var result = controller.GetPlanets();
            var planets = result as IList<Planet> ?? result.ToList();

            // Assert
            Assert.IsNotNull(planets,"GetPlanets should not return Null");
            
            Assert.AreEqual(expectedPlanetCount, planets.Count, String.Format("GetPlanets should have returned {0} planets", expectedPlanetCount));
            Assert.AreEqual(planets[0].Name, testplanetA, String.Format("GetPlanets should return {0} as the first planet's name", testplanetA));
            Assert.AreEqual(planets[0].DistanceToSun, testplanetDistanceA, String.Format("GetPlanets should return {0} as the first planet's distance to the sun", testplanetA));
            Assert.AreEqual(planets[1].Name, testplanetB, String.Format("GetPlanets should return {0} as the second planet's name", testplanetB));
            Assert.AreEqual(planets[1].DistanceToSun, testplanetDistanceB, String.Format("GetPlanets should return {0} as the second planet's distance to the sun", testplanetB));
        }
    }
}
