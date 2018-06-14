var planetDatabase = planetDatabase || {};
planetDatabase.planets = {};

planetDatabase.planets = (function () {
    const planetsUrl = 'http://localhost:8124/Service/api/planets';

    var getAllPlanets = function (callback) {
        const request = new XMLHttpRequest();

        request.open('GET', planetsUrl, true);
        request.onreadystatechange = callback;

        request.send();
    };

    return {
        getAllPlanets: getAllPlanets
    }
}());