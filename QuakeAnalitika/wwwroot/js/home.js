var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {
        makeups: [
            {
                author: {
                    username: "geri"
                },
                name: "My Awesome Makeup",
                steps: [
                    {
                        name: "Put on some string",
                        description: "string string string string string",
                        icon: "mdi-edit",
                        color: "red"
                    },
                    {
                        name: "Put on some oranged",
                        description: "Some awesome description",
                        icon: "mdi-edit",
                        color: "orange"
                    },
                    {
                        name: "Put on some green makeups",
                        description: "Some awesome description 2",
                        icon: "mdi-car",
                        color: "green"
                    }
                ]
            },
            {
                author: {
                    username: "ivan"
                },
                name: "My not Awesome Makeup",
                steps: [
                    {
                        name: "Put on some string",
                        description: "string string string string string",
                        icon: "mdi-edit",
                        color: "red"
                    },
                    {
                        name: "Put on some oranged",
                        description: "Some awesome description",
                        icon: "mdi-edit",
                        color: "orange"
                    },
                    {
                        name: "Put on some green makeups",
                        description: "Some awesome description 2",
                        icon: "mdi-car",
                        color: "green"
                    }
                ]
            },
            {
                author: {
                    username: "petur"
                },
                name: "My not Awesome Makeup",
                steps: [
                    {
                        name: "Put on some string",
                        description: "string string string string string",
                        icon: "mdi-edit",
                        color: "red"
                    },
                    {
                        name: "Put on some oranged",
                        description: "Some awesome description",
                        icon: "mdi-edit",
                        color: "orange"
                    },
                    {
                        name: "Put on some green makeups",
                        description: "Some awesome description 2",
                        icon: "mdi-car",
                        color: "green"
                    }
                ]
            }
        ]
    }
})