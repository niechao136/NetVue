<template>
  <main :style="{backgroundImage: backgroundImage}">
    <nuxt/>
  </main>
</template>
<script lang="ts">
import {Component, Vue} from "nuxt-property-decorator"

@Component({
  fetchOnServer: false,
  fetch(this: Layout) {
    return fetch("biying/image")
      .then(response => response.text())
      .then((data: string) => {
        this.url = data
      })
  },
})
export default class Layout extends Vue {
  url = ""

  get backgroundImage() {
    return `url(${this.url})`
  }
}
</script>
<style lang="scss">
body {
  margin: 0;
  
  main {
    width: 100vm;
    height: 100vh;
    background-size: 100% 100%;
  }
}
</style>