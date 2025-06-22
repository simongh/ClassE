import { dateString } from '@app-types/dateString';

import { PaymentModel } from './payment.model';

export interface Payment extends PaymentModel {
  id: number;
  person: {
    id: number;
    name: string;
  };
}
