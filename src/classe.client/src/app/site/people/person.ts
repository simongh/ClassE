import { Booking } from './booking';
import { Payment } from './payment';

export interface Person {
  firstName: string;
  lastName: string;
  email: string | null;
  phone: string | null;
  credits: number;
  bookings: Booking[];
  waitingList: Booking[];
  payments: Payment[];
}
