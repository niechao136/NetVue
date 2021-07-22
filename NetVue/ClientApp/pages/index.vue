<template>
  <main :style="{backgroundImage: backgroundImage}">

  </main>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import { MetaInfo } from 'vue-meta'
import ClassApi from '~/pages/class-api.vue'

interface Image {
  url: string
}

interface BingImage {
  images: Image[]
}

@Component({
  fetchOnServer: false,
  asyncData() {
    console.log("asyncData")
  },
  fetch (this: Index) {
    console.log("fetch");
    return fetch('/bing/HPImageArchive.aspx?format=js&idx=0&n=1&nc=1626857662422&pid=hp')
        .then(response => response.json())
        .then((data: BingImage) => { this.bingImage = data })
  },
  head (this: ClassApi): MetaInfo {
    return {
      title: 'Demo',
    }
  },
  created() {
    console.log("created");
  }
})
export default class Index extends Vue {
  bingImage: BingImage = { images: [{url: ""}]}
  get backgroundImage(): string {
    return `url(/bing/${this.bingImage.images[0].url})`
  }
}
</script>
<style>
main {
  width: 100vm;
  height: 100vh;
  background-size: 100% 100%;
}
body, ul {
  margin: 0;
}
</style>
