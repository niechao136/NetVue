<template>
  <div>
    
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
  },
  mounted() {
    
  },
})
export default class Index extends Vue {

}
</script>
<style lang="scss" scoped>
</style>
