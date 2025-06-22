import { dayOfWeek } from '@app-types/dayOfWeek';
import { timeString } from '@app-types/timeString';

import { IdName } from '../idname';
import { ClassModel } from './class.model';

export interface Class extends ClassModel {
  venue: IdName;
  bookings: IdName[];
  waitingList: IdName[];
}
