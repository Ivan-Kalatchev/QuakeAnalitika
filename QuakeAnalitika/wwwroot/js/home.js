﻿Vue.component('l-map', window.Vue2Leaflet.LMap);
Vue.component('l-tile-layer', window.Vue2Leaflet.LTileLayer);
Vue.component('l-marker', window.Vue2Leaflet.LMarker);
Vue.component('l-popup', window.Vue2Leaflet.LPopup);

var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {
        isLoading: false,
        url: 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        attribution:
            '&copy; <a target="_blank" href="http://osm.org/copyright">OpenStreetMap</a> contributors',
        zoom: 6,
        center: [42, 25],
        markers: [],
        errText: "",
        errDialog: false
    },
    mounted() {
        this.getNext();
    },
    methods: {

        getNext() {
            try {
                this.isLoading = true;
                axios.get("/api/reports")
                    .then(function (response) {
                        if (response.data[0]) app.markers = response.data;
                        else app.markers = [];
                    })
                    .catch(function (err) {
                        app.errText = err.response.data;
                        app.errDialog = true;
                    })
                    .then(function () {
                        app.isLoading = false;
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