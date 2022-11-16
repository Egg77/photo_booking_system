import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './index.css';
//import App from './App';
import Layout from "./Pages/Layout";
import Home from "./Pages/Home";
import ListBookings from "./Pages/ListBookings";
import AddBooking from "./Pages/AddBooking";
import UpdateBooking from "./Pages/UpdateBooking";
import reportWebVitals from './reportWebVitals';

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

ReactDOM.render(<App />, document.getElementById("root"));

// const root = ReactDOM.createRoot(document.getElementById('root'));
// root.render(
//   <React.StrictMode>
//     <App />
//   </React.StrictMode>
// );

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
