import { dayOfWeek } from '@app-types/dayOfWeek';
import { timeString } from '@app-types/timeString';
import { Venue } from './venue';

export interface Summary {
  id: number;
  dayOfWeek: dayOfWeek;
  startTime: timeString;
  duration: number;
  booked: number;
  waiting: number;
  isActive: boolean;
  venue: Venue;
}
