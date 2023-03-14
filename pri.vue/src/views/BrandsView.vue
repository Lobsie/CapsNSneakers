<template>
  <section>
    <h1 class="is-size-1 my-5">brands</h1>
    <div class="columns is-multiline is-2 is-variable" v-if="brands">
      <BrandFittingComponent
        v-for="brand in brands"
        :key="brand.id"
        :id="brand.id"
        :name="brand.name"
        :link-to="linkTo"
      />
    </div>
  </section>
</template>

<script>
import axios from "axios";
import BrandFittingComponent from "@/components/BrandFittingComponent.vue";

export default {
  name: "BrandsView",
  components: {
    BrandFittingComponent,
  },
  data() {
    return {
      brands: null,
      hasApproved: false,
      linkTo: "brands",
    };
  },
  async mounted() {
    let self = this;

    try {
      const { data } = await axios.get("brands");
      self.brands = data;

      console.log(self.brands);
    } catch (error) {
      console.log(error);
    }
  },
};
</script>
