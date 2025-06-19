import { dayOfWeek } from '@app-types/dayOfWeek';
import { timeString } from '@app-types/timeString';
import { Venue } from './venue';
import { Booking } from './booking';

export interface Class {
  dayOfWeek: dayOfWeek;
  startTime: timeString;
  duration: number;
  isActive: boolean;
  venue: Venue;
  bookings: Booking[];
  waitingList: Booking[];
}
