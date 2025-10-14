import { Booking } from './booking';
import { PersonModel } from './person.model';
import { PaymentModel } from '../payments/payment.model';

export interface Person extends PersonModel {
  balance: number;
  bookings: Booking[];
  waitingList: Booking[];
  payments: PaymentModel[];
}
