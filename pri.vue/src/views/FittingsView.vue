<template>
  <section>
    <h1 class="is-size-1 my-5">Fittings</h1>
    <div class="columns is-multiline is-2 is-variable" v-if="fittings">
      <BrandFittingComponent v-for="fitting in fittings" :key="fitting.id" :id="fitting.id" :name="fitting.name" :link-to="linkTo" />
    </div>
  </section>
</template>

<script>
import axios from "axios";
import BrandFittingComponent from "@/components/BrandFittingComponent.vue";

export default {
  name: "FittingsView",
  components: {
    BrandFittingComponent,
  },
  data() {
    return {
      fittings: null,
      hasApproved: false,
      linkTo: "fittings",
    };
  },
  async mounted() {
    let self = this;

    try {
      const { data } = await axios.get("fittings");
      self.fittings = data;
      console.log(self.fittings);
    } catch (error) {
      console.log(error);
    }
  },
};
</script>
