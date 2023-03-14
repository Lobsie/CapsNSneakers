<template>
  <section></section>
</template>

<script>
import axios from "axios";

export default {
  name: "BrandsDetailView",
  data() {
    return {
      id: this.$route.params.id,
      brand: null,
    };
  },
  async mounted() {
    if (this.id) {
      const { data } = await axios.get(`brands/${this.id}/overview`);

      this.brand = data;

      console.log(data);
    }
  },
};
</script>
