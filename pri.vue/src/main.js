import Vue from "vue";
import App from "./App.vue";
import Buefy from "buefy";
import "buefy/dist/buefy.css";
import axios from "axios";
import VueAxios from "vue-axios";
import Router from "vue-router";
import LoginView from "./views/LoginView.vue";
import BrandsView from "./views/BrandsView.vue";
import BrandDetailView from "./views/BrandDetailView.vue"
import RegisterView from "./views/RegisterView.vue";
import FittingsView from "./views/FittingsView.vue";
import FittingDetailView from "./views/FittingDetailView"
import CapsView from "./views/CapsView.vue";
import CapDetailView from "./views/CapDetailView.vue";
import CreateEditCapView from "./views/CreateEditCapView.vue"
import "./interceptors/axios";

Vue.config.productionTip = false;
Vue.use(Buefy);
Vue.use(Router);
Vue.use(VueAxios, axios);

let isAuthenticated = false;
function guardMyRoutes(to, from, next) {
  if (sessionStorage.getItem("token")) isAuthenticated = true;
  else isAuthenticated = false;

  if (isAuthenticated) next();
  else next("/login");
}

const routes = [
  {
    path: "/login",
    name: "Login",
    meta: { title: "Login", hide: isAuthenticated },
    component: LoginView,
  },
  {
    path: "/register",
    name: "Register",
    meta: { title: "Register", hide: isAuthenticated },
    component: RegisterView,
  },
  {
    path: "/brands",
    name: "Brands",
    meta: { title: "Brands", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: BrandsView,
  },
  {
    path: "/brands/:id",
    name: "Brand",
    meta: { title: "Brand", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: BrandDetailView,
  },
  {
    path: "/caps",
    name: "Caps",
    meta: { title: "Caps", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: CapsView,
  },
  {
    path: "/caps/:id",
    name: "Cap",
    meta: { title: "Cap", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: CapDetailView,
  },
  {
    path: "/caps/:id/edit",
    name: "Edit cap",
    meta: { title: "Edit cap", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: CreateEditCapView,
  },
  {
    path: "/caps/new",
    name: "Create new cap",
    meta: { title: "Create new cap", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: CreateEditCapView,
  },
  {
    path: "/fittings",
    name: "Fittins",
    meta: { title: "Fittins", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: FittingsView,
  },
  {
    path: "/fittings/:id",
    name: "Fitting",
    meta: { title: "Fitting", hide: isAuthenticated },
    beforeEnter: guardMyRoutes,
    component: FittingDetailView,
  }
];

const router = new Router({
  routes,
});

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
