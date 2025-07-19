import { dateString } from '@app-types/dateString';
import { Gender } from '@app-types/gender';

import { Booking } from './booking';
import { PersonModel } from './person.model';
import { PaymentModel } from '../payments/payment.model';

export interface Person extends PersonModel {
  id: number;
  balance: number;
  bookings: Booking[];
  waitingList: Booking[];
  payments: [
    {
      id: number;
    } & PaymentModel
  ];
}
