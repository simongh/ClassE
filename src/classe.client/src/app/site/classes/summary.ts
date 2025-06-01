import { dateString } from '@app-types/dateString';
import { Venue } from './venue';

export interface Summary {
  id: number;
  dayOfWeek: string;
  startDate: dateString;
  endDate: dateString;
  startTime: number;
  duration: number;
  booked: number;
  waiting: number;
  venue: Venue;
}
