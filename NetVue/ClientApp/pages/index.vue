<template>
  <div>
    Index
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "nuxt-property-decorator"
import {MetaInfo} from "vue-meta"

@Component({
  fetchOnServer: false,
  asyncData() {
    console.log("asyncData")
  },
  fetch(this: Index) {
    console.log("fetch");
  },
  head(this: Index): MetaInfo {
    return {
      title: "Index",
    }
  },
  created() {
    console.log("created");
  }
})
export default class Index extends Vue {

}
</script>
