<template>
  <section>
    <div class="hero is-fullheight">
      <div class="hero-body is-justify-content-center is-align-items-center">
        <div class="columns is-flex is-flex-direction-column box">
          <div class="column">
            <b-field label="Username" :label-position="labelPosition">
              <b-input v-model="username"></b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Email" :label-position="labelPosition">
              <b-input type="email" v-model="email"></b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Firstname" :label-position="labelPosition">
              <b-input v-model="firstname"></b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Name" :label-position="labelPosition">
              <b-input v-model="lastname"></b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Password" :label-position="labelPosition">
              <b-input type="password" v-model="password" password-reveal>
              </b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Repeat password" :label-position="labelPosition">
              <b-input type="password" v-model="repeatPassword" password-reveal>
              </b-input>
            </b-field>
          </div>
          <div class="column">
            <b-field label="Date of birth" :label-position="labelPosition">
              <b-datepicker
                v-model="dateOfBirth"
                expanded
                placeholder="Select a date"
              >
              </b-datepicker>
            </b-field>
          </div>
          <div class="column">
            <b-field>
              <b-checkbox v-model="hasApproved"
                >Approve terms and conditions</b-checkbox
              >
            </b-field>
          </div>
          <div class="column">
            <b-button type="is-success" v-on:click="register" outlined
              >Register</b-button
            >
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import axios from "axios";
// import {Router} from "vue-router";

export default {
  name: "RegisterView",
  data() {
    return {
      username: "",
      email: "",
      firstname: "",
      lastname: "",
      password: "",
      repeatPassword: "",
      dateOfBirth: null,
      hasApproved: "",
      labelPosition: "on-border",
    };
  },
  methods: {
    register: async function () {
      const registerRequest = {
        userName: this.username,
        email: this.email,
        firstName: this.firstname,
        lastName: this.lastname,
        dateOfBirth: new Date(this.dateOfBirth).toISOString(),
        password: this.password,
        confirmPassword: this.repeatPassword,
        hasApprovedTermsAndConditions: this.hasApproved,
      };

      const { status } = await axios.post("accounts/register", registerRequest);

      if (status === 200) this.$router.push({ path: "/login" });
    },
  },
};
</script>

<style>
.register-card {
  width: 28rem;
  height: 36rem;
}
</style>
