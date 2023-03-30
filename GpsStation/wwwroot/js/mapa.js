
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

// Adiciona uma pequena referência no canto inferior direito
var tile_layer_dab421bc9de218ab2d83e9c8544b0bb6 = L.tileLayer(
    "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    { "attribution": "Data by \u0026copy; \u003ca target=\"_blank\" href=\"http://openstreetmap.org\"\u003eOpenStreetMap\u003c/a\u003e, under \u003ca target=\"_blank\" href=\"http://www.openstreetmap.org/copyright\"\u003eODbL\u003c/a\u003e.", "detectRetina": false, "maxNativeZoom": 18, "maxZoom": 18, "minZoom": 0, "noWrap": false, "opacity": 1, "subdomains": "abc", "tms": false }
).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);

// Estrutura GeoJson para colocar pontos no mapa
var myGeojsonData = {
    "type": "FeatureCollection",
    "features": [
        {
            "type": "Feature",
            "properties": {
                "name": "São Paulo"
            },
            "geometry": {
                "type": "Point",
                "coordinates": [-46.6333, -23.5505]
            }
        }
    ]
};

// Adiciona a camada GeoJSON
var geojsonLayer = L.geoJSON(myGeojsonData).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);

// Adiciona um marcador
var marker = L.marker([-23.5505, -46.6333]).addTo(map_55bbce51b6ab60a6b4c85363dc2540ad);

// Adiciona um pop-up ao marcador
marker.bindPopup("<b>São Paulo</b><br>Capital do estado de São Paulo.").openPopup();

