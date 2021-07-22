import type { NuxtConfig } from '@nuxt/types'
const path = require("path")

const config: NuxtConfig = {
  build: {},
  buildModules: [
    '@nuxtjs/composition-api/module',
    '@nuxt/typescript-build'
  ],
  generate: {
    dir: path.resolve(__dirname, "..") + "/wwwroot"
  },
  css: [],
  env: {},
  head: {
    title: 'nuxt-community/typescript-template',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: 'A boilerplate to start a Nuxt+TS project quickly' }
    ],
    link: [
      {rel: "icon", type: "image/x-icon", href: "/favicon.ico"}
    ]
  },
  loading: { color: '#0c64c1' },
  modules: [ '@nuxtjs/proxy' ],
  proxy: {
    "/bing": {
      target: "https://cn.bing.com",
      ws: true,
      changOrigin: true,
      pathRewrite: {
        "^/bing": ""
      }
    },
  },
  plugins: [
    '~/plugins/truncate',
  ]
}

export default config
