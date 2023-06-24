

// Cria o mapa
var map_55bbce51b6ab60a6b4c85363dc2540ad = L.map(
    "map_55bbce51b6ab60a6b4c85363dc2540ad",
    {
        center: [0, 0],
        crs: L.CRS.EPSG3857,
        zoom: 1,
        zoomControl: true,
        preferCanvas: false,
    }
).setView([-23.5505, -46.6333], 4);


////adiciona uma pequena refer�ncia no canto inferior direito
var tile_layer_dab421bc9de218ab2d83e9c8544b0bb6 = L.tileLayer(
    "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    { "attribution": "Data by \u0026copy; \u003ca target=\"_blank\" href=\"http://openstreetmap.org\"\u003eOpenStreetMap\u003c/a\u003e, under \u003ca target=\"_blank\" href=\"http://www.openstreetmap.org/copyright\"\u003eODbL\u003c/a\u003e.", "detectRetina": false, "maxNativeZoom": 18, "maxZoom": 18, "minZoom": 0, "noWrap": false, "opacity": 1, "subdomains": "abc", "tms": false }
).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);




function adicionarDadosMapa() {
    latitude = localStorage.getItem("latitude");
    longitude = localStorage.getItem("longitude");
    tipoSalvo = localStorage.getItem("tipo");

    console.log('aa', latitude);
    console.log('bb', longitude)

    tipo = "ponto";
    console.log(tipoSalvo, tipoSalvo != null, tipoSalvo != undefined, tipoSalvo === null)
    if (tipoSalvo != "") {
        tipo = tipoSalvo;
    }

    if ((latitude.trim() != "" && longitude.trim() != "")) {
        console.log('b', latitude, longitude);


        latitudes = latitude.split(',');
        longitudes = longitude.split(',');

        console.log(latitudes, longitudes)
        if (tipo === "ponto") {

            // Estrutura GeoJson para colocar pontos no mapa
            var myGeojsonData = {
                "type": "FeatureCollection",
                "features": [
                    {
                        "type": "Feature",
                        "properties": {
                            "name": "Você"
                        },
                        "geometry": {
                            "type": "Point",
                            "coordinates": [+latitudes[0], +longitude[1]]
                        }
                    }
                ]
            };

            // adiciona o ponto da a camada GeoJSON
            var geojsonLayer = L.geoJSON(myGeojsonData).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);

            // adiciona um marcador
            var marker = L.marker([+longitude[1], +latitudes[0]]).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);

            // adiciona um pop-up ao marcador
            marker.bindPopup("Você está aqui.").openPopup();

        } else if (tipo === "linha") {
            console.log('ok')
            // Cria polyline com coordenadas informadas


            // define as coordenadas da polyline
            var polylinePoints = [];
            for (var c in latitudes) {
                if (latitudes[c].trim() != "") {
                    polylinePoints.push([+latitudes[c], +longitudes[c]])
                }
            }
            console.log(polylinePoints)

            // desenha as linhas no mapa
            var polyline = L.polyline(polylinePoints, { color: 'red' }).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad)
        }
    }
}
