import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { EMPTY, of } from 'rxjs';

import { dateString } from '@app-types/dateString';
import { SearchQuery } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Payment } from './payment';
import { PaymentModel } from './payment.model';

@Injectable({
  providedIn: 'root',
})
export class PaymentsService {
  readonly #httpClient = inject(HttpClient);

  public search(query: SearchQuery) {
    return of<SearchResults<Payment>>({
      total: 0,
      results: [
        {
          id: 99,
          date: '2025-06-01',
          amount: 10,
          credits: 5,
          person: {
            id: 0,
            name: 'Simon Halsey',
          },
        },
      ],
    });
    // const p = toParams(query);
    // return this.#httpClient.get<SearchResults<Summary>>('/api/venues', {
    //   params: p,
    // });
  }

  public get(id: number) {
    return of<Payment>({
      id: 99,
      date: '2025-06-01',
      amount: 0,
      credits: 0,
      person: {
        id: 0,
        name: 'bob bobson',
      },
    });
    //return this.#httpClient.get<Summary>(`/api/payments/${id}`);
  }

  public update(id: number, payment: PaymentRequest) {
    return of(true);
    //return this.#httpClient.put(`/api/payments/${id}`,payment);
  }

  public create(payment: PaymentRequest) {
    return EMPTY;
    // return this.#httpClient.post(`/api/payments`,payment);
  }

  public delete(id: number) {
    return EMPTY;
    //return this.#httpClient.delete(`/api/payments/${id}`);
  }
}

interface PaymentRequest extends PaymentModel {
  person: number;
}
