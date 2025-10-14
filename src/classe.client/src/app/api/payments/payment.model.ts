import { dateString } from '@app-types/dateString';

export interface PaymentModel {
  id: number;
  created: dateString;
  amount: number;
}
