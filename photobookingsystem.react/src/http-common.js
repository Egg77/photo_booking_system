import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:7096/Booking",
  headers: {
    withCredentials: true,
    "Content-type": "application/json",
    "Access-Control-Allow-Credentials": true,
  },
});
