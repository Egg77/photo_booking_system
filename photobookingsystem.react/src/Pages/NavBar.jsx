import React from "react";
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import Container from 'react-bootstrap/Container';

function NavBar() {
  return (
    <Navbar collapseOnSelect expand ="lg" bg="dark" variant="dark">
      <Navbar.Brand style={{marginLeft: 25}} href="/">Home</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="me-auto">
          <Nav.Link href="/bookinglist">Booking List</Nav.Link>
          <Nav.Link href="/newbooking">New Booking</Nav.Link>
          <Nav.Link href="/updatebooking">Update Booking</Nav.Link>
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default NavBar;