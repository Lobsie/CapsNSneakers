<template>
  <section>
    <h1 class="is-size-1 my-5">Caps</h1>
    <div class="columns is-multiline is-2 is-variable" v-if="caps">
      <CapCardComponent
        v-for="cap in caps"
        :key="cap.id"
        :id="cap.id"
        :fitting="cap.fitting.name"
        :brand="cap.brand.name"
        :name="cap.name"
      />
    </div>
  </section>
</template>

<script>
import axios from "axios";
import CapCardComponent from "@/components/CapCardComponent.vue";

export default {
  name: "CapsView",
  components: {
    CapCardComponent,
  },
  data() {
    return {
      caps: null,
      Unauthorized: false,
    };
  },
  async mounted() {
    let self = this;

    try {
      const { status, data } = await axios.get("caps");

      if (status === 200) {
        self.caps = data;
        console.log(self.caps);
      }
    } catch (error) {
      if (error?.response?.status === 403)
        self.Unauthorized = true;

      console.log(error);
    }
  },
};
</script>
