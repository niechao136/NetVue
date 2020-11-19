const path = require("path")

export default {
    env: {},
    head: {
        title: "Home",
        meta: [
            {charset: "utf-8"},
            {name: "viewport", content: "width=device-width, initial-scale=1"},
            {hid: "description", name: "description", content: "Nuxt.js TypeScript project"}
        ],
        link: [
            {rel: "icon", type: "image/x-icon", href: "/favicon.ico"}
        ]
    },
    loading: {
        color: "#3B8070"
    },
    css: [
        "~/assets/scss/main.scss"
    ],
    build: {
        loaders: {
            imgUrl: {
                esModule: false
            }
        }
    },
    generate: {
        dir: path.resolve(__dirname, "..") + "/wwwroot"
    },
    buildModules: [
        "@nuxt/typescript-build"
    ],
    plugins: [
        "~/plugins/cookies.ts",
        "~/plugins/element.ts",
    ],
    modules: [
        "@nuxtjs/axios",
    ],
    axios: {}
}
