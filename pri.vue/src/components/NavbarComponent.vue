<template>
  <header>
    <b-navbar fixed-top centered class="is-dark mb-6">
      <template #brand>
        <b-navbar-item tag="router-link" :to="{ path: '/' }">
          Caps-N-Sneakers
        </b-navbar-item>
      </template>
      <template #start>
        <b-navbar-item tag="router-link" :to="{ path: '/' }"> Home </b-navbar-item>
        <b-navbar-item tag="router-link" :to="{ path: '/brands' }"> Brands </b-navbar-item>
        <b-navbar-item tag="router-link" :to="{ path: '/fittings' }"> Fittings </b-navbar-item>
        <b-navbar-item tag="router-link" :to="{ path: '/caps' }"> Caps </b-navbar-item>
    </template>

      <template #end>
        <b-navbar-item tag="div">
          <div class="buttons">
            <router-link v-if="!authorized" class="button is-succes" to="/register">
              <strong>Register</strong>
            </router-link>
            <router-link v-if="!authorized" class="button is-warning" to="/login" > Log in </router-link>
            <router-link v-if="authorized" class="button is-danger" to="/login" > Logout </router-link>
          </div>
        </b-navbar-item>
      </template>
    </b-navbar>
  </header>
</template>

<script>
export default {
  name: "NavbarComponent",
  data() {
    return {
      authorized:false
    }
  },
  created: function () {
    let self = this;
    self.checkIfLoggedIn();
  },
  methods: {
    checkIfLoggedIn: function () {
      const token = sessionStorage.getItem("token");
      console.log(token != null);
      this.authorized = token != null;
    }
  }
};
</script>
