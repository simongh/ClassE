import { dayOfWeek } from '@app-types/dayOfWeek';
import { timeString } from '@app-types/timeString';

export interface ClassModel {
  dayOfWeek: dayOfWeek;
  startTime: timeString;
  duration: number;
  isActive: boolean;
}
