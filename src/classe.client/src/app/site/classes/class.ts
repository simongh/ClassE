import { dateString } from '@app-types/dateString';
import { Venue } from './venue';
import { Booking } from './booking';

export interface Class {
  stateDate: dateString;
  endDate: dateString;
  startTime: number;
  duration: number;
  venue: Venue;
  bookings: Booking[];
  waitingList: Booking[];
}
