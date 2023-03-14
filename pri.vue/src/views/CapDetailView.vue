<template>
  <section>
    <div v-if="cap" class="container product-detail box m-5">
      <div class="columns">
        <div
          class="column is-hidden-desktop is-1-tablet is-hidden-mobile"
        ></div>

        <div class="column is-5-desktop is-5-tablet is-12-mobile">
          <img
            src="https://hatstore.imgix.net/HS1018966_1.jpg?auto=compress%2Cformat&w=544&h=435&q=50"
            alt="image"
            style="max-height: 500px"
          />
        </div>

        <div
          class="column is-7-desktop is-5-tablet is-12-mobile content-detail"
        >
          <h1 class="is-size-1">{{ cap.name }}</h1>
          <h2 class="is-size-3">{{ cap.brand.name }}</h2>
          <p class="is-size-4">{{ cap.fitting.name }}</p>
          <ul>
            <li>{{ cap.colorway }}</li>
            <li>{{ cap.material }}</li>
          </ul>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "CapDetailView",
  data() {
    return {
      id: this.$route.params.id,
      cap: null,
    };
  },
  async mounted() {
    if (this.id) {
      const { data } = await axios.get(`caps/${this.id}`);

      this.cap = data;

      console.log(data);
    }
  },
};
</script>
