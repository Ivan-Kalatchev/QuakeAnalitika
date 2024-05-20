var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {
        picture: null,
        pictureBase64: null,
        isLoading: false,
        // username
        user: "",
        email: "",
        // password stored in clear text
        password: "",
        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,
    },
    watch: {
        picture(val) {
            var reader = new FileReader();
            reader.onloadend = () => app.pictureBase64 = reader.result;
            reader.readAsDataURL(val);
        }
    },
    methods: {
        // Authenticate user
        login() {

            try {
                this.isLoading = true;
                axios.post("api/users", { "userName": app.user, "picture": app.pictureBase64, "email": app.email, "password": app.password })
                    .then(function (response) {
                       window.location.href = "/";
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