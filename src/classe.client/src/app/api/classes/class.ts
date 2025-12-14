import { IdName } from '../idname';
import { ClassModel } from './class.model';
import { SessionSummary } from './session-summary';

export interface Class extends ClassModel {
  cost: number;
  venue: IdName;
  bookings: IdName[];
  waitingList: IdName[];
  sessions: SessionSummary[];
}
