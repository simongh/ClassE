import { dateString } from '@app-types/dateString';

export interface SessionSummary
{
    id: number;
    date: dateString;
    expected: number;
    attended: number;
}