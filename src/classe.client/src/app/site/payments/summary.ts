import { dateString } from '@app-types/dateString';

export interface Summary {
  date: dateString;
  amount: number;
  credits: number;
  person: {
    id: number;
    name: string;
  };
}
