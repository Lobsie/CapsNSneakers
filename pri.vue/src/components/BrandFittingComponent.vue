<template>
    <div class="column is-one-third">
      <div class="card">
        <header class="card-header">
          <p class="card-header-title">{{ name }}</p>
        </header>
        <div class="card-content">
          <div class="content">
            
          </div>
        </div>
        <footer class="card-footer">
          <router-link
            :to="`/${linkTo}/${id}`"
            class="card-footer-item"
            >View</router-link
          >
          <a href="#" class="card-footer-item">Edit</a>
          <a href="#" class="card-footer-item">Delete</a>
        </footer>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "NavbarComponent",
    props: {
      id: null,
      name: null,
      linkTo: null
    },
  };
  </script>
  
  <style>
  .card {
    border: 1px solid black;
  }
  </style>
  