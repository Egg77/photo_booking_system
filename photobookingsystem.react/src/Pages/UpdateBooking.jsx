import React, { useState} from "react";
import {useDispatch} from 'react-redux';
import {updateBooking, deleteBooking} from '../Actions/bookings';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Modal from 'react-bootstrap/Modal';
import {useNavigate, useLocation} from 'react-router-dom';


const UpdateBooking = () => {

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const navigate = useNavigate();
    const location = useLocation();

    
    const [booking, setBooking] = useState(location.state.currentBooking);
    const [validated, setValidated] = useState(false);

    const dispatch = useDispatch();

    const handleInputChange = event => {
        const { name, value } = event.target;
        console.log(event.target);
        setBooking({ ...booking, [name]: value });
      };

    const handleSubmit = (event) => {
        const form = event.currentTarget;
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
        }
        setValidated(true);
        
        const { bookingId,
            clientName, 
            clientEmail,
            clientPhone,
            address,
            startDateTime,
            photo,
            video,
            comments,
            price,
            paid } = booking;

        dispatch(updateBooking(bookingId, clientName, clientEmail, clientPhone, address, startDateTime, photo, video, comments, price, paid))
        .then(data => {
        setBooking({
            id : data.bookingId,
            clientName : data.clientName,
            clientEmail : data.clientEmail,
            clientPhone : data.clientPhone,
            address : data.address,
            startDateTime : data.startDateTime,
            photo : data.photo,
            video : data.video,
            comments : data.comments,
            price : data.price,
            paid : data.paid
        });
        console.log(data);
        navigate("/");
        })
        .catch(e => {
            console.log(e);
        });
    }

    const deleteBookingConfirm = () => {
        dispatch(deleteBooking(booking.bookingId))
        .then(() => {
            navigate("/");
        })
        .catch(e => {
            console.log(e);
            });
        };

    return (
        <>
        <h1>Update Booking</h1>
        <Container>
            <Form noValidate validated={validated} onSubmit={handleSubmit}>
                <Form.Group>
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        required
                        name='clientName'
                        value={booking.clientName}
                        onChange={handleInputChange}
                        />
                <Form.Control.Feedback type="invalid">Please enter a name</Form.Control.Feedback>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                        required
                        name='clientEmail'
                        type='email'
                        placeholder='Enter email'
                        value={booking.clientEmail}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Phone Number</Form.Label>
                    <Form.Control 
                        required
                        type='tel' 
                        name='clientPhone'
                        value={booking.clientPhone}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Booking Date</Form.Label>
                    <Form.Control 
                        required
                        type='datetime-local' 
                        name='startDateTime'
                        value={booking.startDateTime}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Address</Form.Label>
                    <Form.Control 
                        required
                        type='text' 
                        name='address'
                        value={booking.address}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Number of Photos</Form.Label>
                    <Form.Control 
                        required
                        type='number' 
                        name='photo'
                        min='0'
                        max='200'
                        value={booking.photo}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Minutes of Video</Form.Label>
                    <Form.Control
                        required 
                        type='number' 
                        name='video'
                        min='0'
                        max='10'
                        value={booking.video}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Comments</Form.Label>
                    <Form.Control 
                        required
                        type='text' 
                        name='comments'
                        maxLength='500'
                        value={booking.comments}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Price</Form.Label>
                    <Form.Control 
                        type='currency' 
                        name='price'
                        value={booking.price}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Button type='button' onClick={handleSubmit}>Submit</Button>
                <Button variant="danger" onClick={handleShow}>
                Delete
            </Button>
            </Form>
            </Container>

        <Modal show ={show} onHide={handleClose}>
        <Modal.Header closeButton>
            <Modal.Title>Delete Booking?!</Modal.Title>
        </Modal.Header>
        <Modal.Body>Are you sure you want to delete this booking?</Modal.Body>
        <Modal.Footer>
            <Button variant="danger" onClick={deleteBookingConfirm}>OK</Button> {}
            <Button variant="secondary" onClick={handleClose}>Cancel</Button>
        </Modal.Footer>
        </Modal>
        </>
    );
}

export default UpdateBooking;