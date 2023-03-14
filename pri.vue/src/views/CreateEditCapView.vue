<template>
  <section>
    <b-field label="brands">
      <b-select v-model="brandId" placeholder="Select a fitting">
        <option v-for="brand in brands" :value="brand.id" :key="brand.id">
          {{ brand.name }}
        </option>
      </b-select>
    </b-field>
    <b-field v-model="fittingId" label="brands">
      <b-select placeholder="Select a brand">
        <option v-for="fitting in fittings" :value="fitting.id" :key="fitting.id">
          {{ fitting.name }}
        </option>
      </b-select>
    </b-field>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "CreateEditCapView",
  data() {
    return {
      id: this.$route?.id,
      cap: null,
      brands: null,
      fittings: null,

      fittingId: null,
      brandId: null,
      name: null,
      material: null,
      colorway: null,
    };
  },
  async mounted() {
    this.getFittings();
    this.getBrands();
    if (this.id) {
      const { data } = await axios.get(`caps/${this.id}`);

      this.cap = data;
    }
  },
  methods: {
    async getFittings() {
      const { data } = await axios.get("fittings");

      this.fittings = data;
    },
    async getBrands() {
      const { data } = await axios.get("brands");

      this.brands = data;
    },
    async putEditCap() {
        let newCap = {
            id: this.id,
            name: this.name,
            material: this.material,
            colorway: this.colorway,
            fittingId: this.fittingId,
            materialId: this.materialId
        }

        await axios.put(`caps/${this.id}`, {newCap})
    }
  },
};
</script>
