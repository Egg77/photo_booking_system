import axios from "axios";

export default axios.create({
  // baseURL: "https://localhost:7096/Booking",
  baseURL: "https://photobookingsystem-backend.azurewebsites.net/Booking",
  headers: {
    withCredentials: true,
    "Content-type": "application/json",
    "Access-Control-Allow-Credentials": true,
  },
});
