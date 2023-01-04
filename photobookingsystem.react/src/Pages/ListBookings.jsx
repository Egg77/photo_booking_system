import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {getBookingList} from '../Actions/bookings';
import ListGroup from 'react-bootstrap/ListGroup';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import {Link} from 'react-router-dom'


const ListBookings = () => {

    const [currentBooking, setCurrentBooking] = useState(null);
    const [currentIndex, setCurrentIndex] = useState(-1);
    const bookings = useSelector(state => state.bookings);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getBookingList());
        },[]);
        
    // const refreshData = () => {
    //     setCurrentBooking(null);
    //     setCurrentIndex(-1);
    // };

    const setActiveBooking = (index, booking) => {

        setCurrentBooking(booking);
        setCurrentIndex(index);
    };

    return (
        <>
            <h1>Booking List</h1>
            <Row>
                <Col sm={5}>
                    <ListGroup>
                    {bookings &&
                        bookings.map((booking, index) => (
                        <li
                            className={
                            "list-group-item " + (index === currentIndex ? "active" : "")
                            }
                            onClick={() => setActiveBooking(index, booking)}
                            key={index}
                        >
                            <Container>
                                <Row>
                                    <Col sm={2}>{booking.clientName}</Col>
                                    <Col sm={5}>{booking.startDateTime}</Col>
                                    <Col sm>{booking.address}</Col>
                                </Row>
                            </Container>
                        </li>
                        ))}
                    </ListGroup>
                </Col>
                <Col sm>
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
                                    <Link to='/updatebooking' state={{currentBooking}}>
                                        Modify
                                    </Link>
                                </Col>
                            </Row>
                        </Container>
                    ) : (
                        <div>
                        <br />
                            <p>...click on a Booking!</p>
                        </div>
                    )}
                </Col>
            </Row>
        </>
    );
};
    
export default ListBookings;