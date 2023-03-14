import axios from "axios";

axios.defaults.baseURL = "https://localhost:5001/api/";

let refresh = false;

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    let token = sessionStorage.getItem("token");
    let reToken = sessionStorage.getItem("refreshToken");

    console.log(error);

    if (error?.response?.status === 401 && !refresh) {
      refresh = true;

      const { status, data } = await axios.post("accounts/refreshtoken", {
        accessToken: token,
        refreshToken: reToken,
      });

      if (status === 200) {

        sessionStorage.setItem("token", data.token);
        sessionStorage.setItem("refreshToken", data.refreshToken);
        sessionStorage.setItem("expiration", data.expiration);

        axios.defaults.headers.common["Authorization"] = `Bearer ${data.token}`;

        return axios(error.config);
      }
    }
    refresh = false; 
    return error;
  }
);
