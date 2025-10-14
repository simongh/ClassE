import { Injectable } from '@angular/core';
import { NgbDateAdapter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Injectable()
export class DateStringAdapter extends NgbDateAdapter<string>
{
    public override fromModel(value: string | null): NgbDateStruct | null {
        if (!value) {
            return null;
        }

        const d = new Date(value);

        return {
            year: d.getFullYear(),
            month: d.getMonth() + 1,
            day: d.getDate()
        }
    }

    public override toModel(date: NgbDateStruct | null): string | null {
        if (!date) {
            return null;
        }

        return `${date.year}-${date.month}-${date.day}`;
    }
}