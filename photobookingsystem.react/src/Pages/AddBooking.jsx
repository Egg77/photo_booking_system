import React, {useState} from 'react';
import {useDispatch} from 'react-redux';
import {createBooking} from '../Actions/bookings';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';

function AddBooking(){

    const initialBookingState = {

        clientName : "",
        clientEmail : "",
        clientPhone : "",
        address: "",
        startDateTime : "",
        photo : "",
        video : "",
        comments : "",
        price : "",
        paid : 0
    };
    const [booking, setBooking] = useState(initialBookingState);
    const [submitted, setSubmitted] = useState(false);
    const [validated, setValidated] = useState(false);

    const dispatch = useDispatch();

    const handleInputChange = event => {
        const { name, value } = event.target;
        setBooking({ ...booking, [name]: value });
      };

    
    const handleSubmit = (event) => {
        const form = event.currentTarget;
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            setValidated(false);
            console.log("validated: " + validated);
        }
        else if (form.checkValidity() === true)
        {
            setValidated(true);
            console.log("validated?: " + validated);
            saveBooking();
        }
    };
    
    const saveBooking = () => {
        const { clientName, 
                clientEmail,
                clientPhone,
                address,
                startDateTime,
                photo,
                video,
                comments,
                price,
                paid } = booking;

        dispatch(createBooking(clientName, clientEmail, clientPhone, address, startDateTime, photo, video, comments, price, paid))
        .then(data => {
        setBooking({
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
        setSubmitted(true);
      }).catch(e => {
        console.log(e);
        });
    };

    return (
        <>
        <h1>New Booking</h1>
        { submitted ? (
            <Container>
                <h5>Booking successfully created!</h5>
            </Container>
        ) : (
            <Container>
            <Form noValidate validated={validated} onSubmit={handleSubmit}>
                <Form.Group>
                    <Form.Label>Name</Form.Label>
                    <Form.Control
                        required
                        name='clientName'
                        value={booking.clientName}
                        onChange={handleInputChange}/>
                    <Form.Control.Feedback type="invalid">Please enter a name.</Form.Control.Feedback>
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
                    <Form.Control.Feedback type="invalid">Please enter a valid e-mail address.</Form.Control.Feedback>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Phone Number</Form.Label>
                    <Form.Control 
                        required
                        type='tel' 
                        name='clientPhone'
                        value={booking.clientPhone}
                        onChange={handleInputChange}/>
                    <Form.Control.Feedback type="invalid">Please enter a phone number.</Form.Control.Feedback>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Booking Date</Form.Label>
                    <Form.Control 
                        required
                        type='datetime-local' 
                        name='startDateTime'
                        value={booking.startDateTime}
                        onChange={handleInputChange}/>
                    <Form.Control.Feedback type="invalid">Please enter a date.</Form.Control.Feedback>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Address</Form.Label>
                    <Form.Control 
                        required
                        type='text' 
                        name='address'
                        value={booking.address}
                        onChange={handleInputChange}/>
                    <Form.Control.Feedback type="invalid">Please enter an address.</Form.Control.Feedback>
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
                    <Form.Control.Feedback type="invalid">Please enter a value between 0 and 200.</Form.Control.Feedback>
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
                    <Form.Control.Feedback type="invalid">Please enter a value between 0 and 10.</Form.Control.Feedback>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Comments</Form.Label>
                    <Form.Control 
                        type='text' 
                        name='comments'
                        maxLength='500'
                        value={booking.comments}
                        onChange={handleInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Price</Form.Label>
                    <Form.Control
                        required
                        type='currency' 
                        name='price'
                        value={booking.price}
                        onChange={handleInputChange}/>
                    <Form.Control.Feedback type="invalid">Please enter a price.</Form.Control.Feedback>
                </Form.Group>
                <Button type='button' onClick={handleSubmit}>Submit</Button>
            </Form>
            </Container>
        )}
        </>

    );
};

export default AddBooking;