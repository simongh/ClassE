import { dateString } from '@app-types/dateString';

export interface Payment {
  id: number;
  created: dateString;
  amount: number;
  classes: number;
}
