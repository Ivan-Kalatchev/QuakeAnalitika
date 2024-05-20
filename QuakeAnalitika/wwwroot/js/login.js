var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {
        isLoading: false,
        // username
        user: "",
        // password stored in clear text
        password: "",
        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,
    },
    methods: {
        // Authenticate user
        login() {

            try {
                this.isLoading = true;
                axios.post("/login", { "userName": app.user, "password": app.password })
                    .then(function (response) {
                        const urlParams = new URLSearchParams(window.location.search);
                        const returnUrl = urlParams.get('ReturnUrl');
                        if (!returnUrl) window.location.href = "/home";
                        else window.location.href = returnUrl;
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