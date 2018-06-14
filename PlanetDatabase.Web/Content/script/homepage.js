document.addEventListener('DOMContentLoaded',
    function () {
        loadData();
        bindEvents();
    });

var loadData = function () {
    var renderPlanets = function (planets) {
        const target = document.getElementById('planets');
        var planetElements = '';

        planets.forEach(function (planet) {
            planetElements += `
                            <div class ="planet">
                                <span data-id="planet-name" class="planet-name">${planet.Name}</span>
                                <span data-id="planet-info" class ="planet-info hidden">${planet.DistanceToSun.toLocaleString()} km from Sun</span>
                            </div>
                        `;
        });

        target.innerHTML = planetElements;
    }

    const processGetPlanetsResponse = function () {
        if (this.readyState === 4 && this.status === 200) {
            const planets = JSON.parse(this.responseText);
            renderPlanets(planets);
        }
    };

    planetDatabase.planets.getAllPlanets(processGetPlanetsResponse);
}

var bindEvents = function () {
    const target = document.getElementById('planets');
    target.addEventListener('click', function (e) {
        if (e.target && e.target.getAttribute('data-id') === 'planet-name') {
            e.target.nextElementSibling.classList.toggle('hidden');
        }
    });
}