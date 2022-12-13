import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './index.css';
import Layout from "./Pages/Layout";
import Home from "./Pages/Home";
import ListBookings from "./Pages/ListBookings";
import AddBooking from "./Pages/AddBooking";
import UpdateBooking from "./Pages/UpdateBooking";
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Provider} from "react-redux";
import store from "./store.js";

export default function App() {
  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="bookinglist" element={<ListBookings />} />
        <Route path="newbooking" element={<AddBooking />} />
        <Route path="updatebooking" element={<UpdateBooking />} />
      </Route>
    </Routes>
  </BrowserRouter>
  );
}

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>, document.getElementById("root"));

reportWebVitals();
