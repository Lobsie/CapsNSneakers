<template>
  <div class="column is-one-third">
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">{{ name }}</p>
      </header>
      <div class="card-content">
        <div class="content">
          <p>{{ brand }}</p>
          <p>{{ fitting }}</p>
        </div>
      </div>
      <footer class="card-footer">
        <router-link :to="`/caps/${id}`" class="card-footer-item"
          >View</router-link
        >
        <router-link :to="`/caps/${id}/edit`" class="card-footer-item">Edit</router-link>
        <a @click="confirmCustomDelete" class="card-footer-item">Delete</a>
      </footer>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "NavbarComponent",
  props: {
    id: null,
    name: null,
    brand: null,
    fitting: null,
  },
  methods: {
    confirmCustomDelete() {
      let deleteId = this.id;

      this.$buefy.dialog.confirm({
        title: "Deleting cap",
        message:
          "Are you sure you want to <b>delete</b> this cap? This action cannot be undone.",
        confirmText: "Delete Cap",
        type: "is-danger",
        hasIcon: true,

        onConfirm: async function () {
          const { data } = await axios.delete("caps/" + deleteId);

          console.log(data);

          this.$buefy.toast.open("cap deleted!");

          this.$router.push({ path: "/caps" });
        },
      });
    },
  },
};
</script>

<style>
.card {
  border: 1px solid black;
}
</style>
