// Not currently used!

import React, { useState, useEffect, View } from "react";
import { useDispatch, useSelector } from "react-redux";
import {getBookingList} from '.../Actions/bookings';
import ListGroup from 'react-bootstrap/ListGroup';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';


const Booking = (props) => {

    const initialBookingState = {
        id : null,
        ClientName : "",
        startDateTime : null,
        address : "",
        clientPhone : "",
        clientEmail : "",
        photo : null,
        video : null,
        comments : "",
        price : null
    };

    const [currentBooking, setCurrentBooking] = useState(null);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getBooking());
        },[]);

    return( 
    <>
    <h5>Current Booking</h5>
    {currentBooking ? (
        <Container>
            <Row>
                <label>
                    <strong>Name </strong>
                </label>{" "}
                <p>{currentBooking.clientName}</p>
            </Row>
            <Row>
                <label>
                    <strong>Date & Time </strong>
                </label>{" "}
                <p>{currentBooking.startDateTime}</p>
            </Row>
            <Row>
                <label>
                    <strong>Address </strong>
                </label>{" "}
                <p>{currentBooking.address}</p>
            </Row>
            <Row>
                <label>
                    <strong>Phone </strong>
                </label>{" "}
                <p>{currentBooking.clientPhone}</p>
            </Row>
            <Row>
                <label>
                    <strong>E-mail </strong>
                </label>{" "}
                <p>{currentBooking.clientEmail}</p>
            </Row>
            <Row>
                <label>
                    <strong>Photos </strong>
                </label>{" "}
                <p>{currentBooking.photo}</p>
            </Row>
            <Row>
                <label>
                    <strong>Video (minutes) </strong>
                </label>{" "}
                <p>{currentBooking.video}</p>
            </Row>
            <Row>
                <label>
                    <strong>Comments </strong>
                </label>{" "}
                <p>{currentBooking.comments}</p>
            </Row>
            <Row>
                <label>
                    <strong>Quoted Price </strong>
                </label>{" "}
                <p>${currentBooking.price}</p>
            </Row>
            <Row>
                <Col>
                <Button variant="danger" onClick={handleShow}>
                    Delete
                </Button>
                </Col>
                <Col>
                <Button variant ='primary'>
                    Modify
                </Button>
                </Col>
            </Row>
        </Container>

    ) : (
        <div>
        <br />
            <p>...click on a Booking!</p>
        </div>
    )}
        </>
        );
    };

export default Booking;