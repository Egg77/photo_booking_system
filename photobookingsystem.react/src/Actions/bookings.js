import {
  CREATE_BOOKING,
  GET_BOOKING,
  GET_BOOKING_LIST,
  UPDATE_BOOKING,
  DELETE_BOOKING,
} from "./types";

import BookingService from "../Services/BookingService.js";

export const getBookingList = () => async (dispatch) => {
  try {
    const result = await BookingService.getBookingList();

    dispatch({
      type: GET_BOOKING_LIST,
      payload: result.data,
    });
  } catch (error) {
    console.log(error);
  }
};

export const getBooking = (id) => async (dispatch) => {
  try {
    const result = await BookingService.getBooking(id);

    dispatch({
      type: GET_BOOKING,
      payload: result.data,
    });
  } catch (error) {
    console.log(error);
  }
};

export const createBooking = (data) => async (dispatch) => {
  try {
    const result = await BookingService.createBooking(data);

    dispatch({
      type: CREATE_BOOKING,
      payload: result.data,
    });

    return Promise.resolve(result.data);
  } catch (error) {
    return Promise.reject(error);
  }
};

export const updateBooking = (id, data) => async (dispatch) => {
  try {
    const result = await BookingService.updateBooking(id, data);

    dispatch({
      type: UPDATE_BOOKING,
      payload: result.data,
    });

    return Promise.resolve(result.data);
  } catch (error) {
    return Promise.reject(error);
  }
};

export const deleteBooking = (id) => async (dispatch) => {
  try {
    const result = await BookingService.deleteBooking(id);

    dispatch({
      type: DELETE_BOOKING,
      payload: result.data,
    });
  } catch (error) {
    console.log(error);
  }
};
