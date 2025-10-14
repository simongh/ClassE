import { PaymentModel } from './payment.model';

export interface Payment extends PaymentModel {
  person: {
    id: number;
    name: string;
  };
}
