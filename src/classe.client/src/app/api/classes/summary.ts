import { ClassModel } from './class.model';
import { IdName } from '../idname';

export interface Summary extends ClassModel {
  id: number;
  booked: number;
  waiting: number;
  venue: IdName;
}
