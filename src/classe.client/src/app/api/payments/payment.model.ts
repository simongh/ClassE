import { dateString } from '@app-types/dateString';

export interface PaymentModel
{
    date: dateString;
    amount: number;
    credits: number;
}