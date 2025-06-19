import { dateString } from '@app-types/dateString';
import { Booking } from './booking';

export interface Person {
  firstName: string;
  lastName: string;
  email: string | null;
  phone: string | null;
  credits: number;
  bookings: Booking[];
  waitingList: Booking[];
  payments: [
    {
      id: number;
      created: dateString;
      amount: number;
      classes: number;
    }
  ];
}
