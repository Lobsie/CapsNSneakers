<template>
  <section>
    <div class="hero is-fullheight-with-navbar">
      <div class="hero-body is-justify-content-center is-align-items-center">
        <div class="columns is-flex is-flex-direction-column box">
          <div class="column">
            <b-field label="Name" :label-position="labelPosition">
              <b-input v-model="loginName"></b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Password" :label-position="labelPosition">
              <b-input type="password" v-model="loginPassword"> </b-input>
            </b-field>
          </div>
          <div class="column">
            <b-button type="is-success is-fullwidth" v-on:click="login" outlined
              >Login</b-button
            >
          </div>
          <div class="has-text-centered">
            <p class="is-size-7">
              Don't have an account?
              <a href="#" class="has-text-primary">Sign up</a>
            </p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "LoginView",
  data() {
    return {
      loginName: "",
      loginPassword: "",
      labelPosition: "on-border",
    };
  },
  methods: {
    login: async function () {
      const auth = { login: this.loginName, password: this.loginPassword };

      console.log(auth);

      axios
        .post("accounts/login", auth)
        .then(function (response) {
          const data = response.data;
          sessionStorage.setItem("token", data.token);
          sessionStorage.setItem("refreshToken", data.refreshToken);
          sessionStorage.setItem("expiration", data.expiration);

          axios.defaults.headers.common[
            "Authorization"
          ] = `Bearer ${data.token}`;
        })
        .catch((errors) => {
          console.log(errors);
        });

      this.$router.push({ path: "/" });
    },
  },
};
</script>

<style></style>
