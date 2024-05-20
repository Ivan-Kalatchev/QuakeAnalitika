
Vue.component('l-map', window.Vue2Leaflet.LMap);
Vue.component('l-tile-layer', window.Vue2Leaflet.LTileLayer);
Vue.component('l-marker', window.Vue2Leaflet.LMarker);
Vue.component('l-popup', window.Vue2Leaflet.LPopup);

var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {

        marker: [42.09822241118974, 27.641601562500004],
        amount: 1,
        url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        attribution:
            '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
        zoom: 6,
        center: [42, 25],

        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,

    },
    methods: {

        onMapReady(map) {
            map.on('click', app.addMarker)
        },

        addMarker(e) {
            this.marker = [e.latlng.lat, e.latlng.lng];
        },

        save() {
            try {
                axios.post("/api/reports", { "lat": app.marker[0], "lang": app.marker[1], "amount": app.amount })
                    .then(function (response) {
                        window.location.href = "/home";
                    })
                    .catch(function (err) {
                        app.errText = err.response.data;
                        app.errDialog = true;
                    });
            }
            // Something went horrablly wrong!
            catch (err) {
                this.isLoading = false;
                this.errText = "Нещо се обърка!";
                this.errDialog = true;
            }
        }
    }
})