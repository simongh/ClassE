import { dayOfWeek } from '@app-types/dayOfWeek';
import { timeString } from '@app-types/timeString';

import { Booking } from './booking';
import { Venue } from './venue';

export interface Class {
  dayOfWeek: dayOfWeek;
  startTime: timeString;
  duration: number;
  isActive: boolean;
  venue: Venue;
  bookings: Booking[];
  waitingList: Booking[];
}
