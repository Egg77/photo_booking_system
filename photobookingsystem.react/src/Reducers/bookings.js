import {
  CREATE_BOOKING,
  GET_BOOKING,
  GET_BOOKING_LIST,
  UPDATE_BOOKING,
  DELETE_BOOKING,
} from "../Actions/types.js";

const initialState = [];

function bookingReducer(bookings = initialState, action) {
  const { type, payload } = action;

  switch (type) {
    case CREATE_BOOKING:
      return [...bookings, payload];

    case GET_BOOKING_LIST:
      return payload;

    case GET_BOOKING:
      return payload;

    case UPDATE_BOOKING:
      return bookings.map((booking) => {
        if (booking.id === payload.id) {
          return {
            ...booking,
            ...payload,
          };
        } else {
          return booking;
        }
      });

    case DELETE_BOOKING:
      return bookings.filter(({ id }) => id !== payload.id);

    default:
      return bookings;
  }
}

export default bookingReducer;
