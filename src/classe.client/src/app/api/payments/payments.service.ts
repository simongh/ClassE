import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';

import { dateString } from '@app-types/dateString';
import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Payment } from './payment';

export type PaymentForm = ReturnType<PaymentsService['createForm']>['value'];

@Injectable({
  providedIn: 'root',
})
export class PaymentsService {
  readonly #httpClient = inject(HttpClient);

  readonly #fb = inject(NonNullableFormBuilder);

  public createForm() {
    return this.#fb.group({
      created: [null as dateString | null, Validators.required],
      amount: [0, Validators.required],
      person: [null as number | null, Validators.required],
    });
  }

  public search(query: SearchQuery) {
    const p = toParams(query);
    return this.#httpClient.get<SearchResults<Payment>>('/api/payments', {
      params: p,
    });
  }

  public get(id: number) {
    return this.#httpClient.get<Payment>(`/api/payments/${id}`);
  }

  public update(id: number, payment: PaymentForm) {
    return this.#httpClient.put(`/api/payments/${id}`, payment);
  }

  public create(payment: PaymentForm) {
    return this.#httpClient.post(`/api/payments`, payment);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/payments/${id}`);
  }
}
