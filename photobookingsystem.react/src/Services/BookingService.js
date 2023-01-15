import http from "../http-common";

const getBookingList = () => {
  return http.get("/BookingList");
};

const getBooking = (id) => {
  return http.get(`/${id}`);
};

const createBooking = (data) => {
  return http.put("/Create", data);
};

const updateBooking = (id, data) => {
  return http.patch(`/Update/${id}`, data);
};

const deleteBooking = (id) => {
  return http.delete(`/Delete/${id}`);
};

const BookingService = {
  getBookingList,
  getBooking,
  createBooking,
  updateBooking,
  deleteBooking,
};

export default BookingService;
