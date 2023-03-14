<template>
  <section></section>
</template>

<script>
import axios from "axios";

export default {
  name: "FittingDetailView",
  data() {
    return {
      id: this.$route.params.id,
      fitting: null,
    };
  },
  async mounted() {
    if (this.id) {
      const { data } = await axios.get(`fittings/${this.id}/overview`);

      this.fitting = data;

      console.log(data);
    }
  },
};
</script>
