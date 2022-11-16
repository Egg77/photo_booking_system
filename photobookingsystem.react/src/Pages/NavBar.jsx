import React from "react";
import { BrowserRouter, Route, Link } from "react-router-dom";

function NavBar() {
  return (
    <nav>
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/bookinglist">Booking List</Link>
        </li>
        <li>
          <Link to="/newbooking">New Booking</Link>
        </li>
        <li>
          <Link to="/updatebooking">Update Booking</Link>
        </li>
      </ul>
    </nav>
  );
}

export default NavBar;