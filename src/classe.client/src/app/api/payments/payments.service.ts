import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { NonNullableFormBuilder, Validators } from '@angular/forms';

import { injectApi } from '@app-types/ApiResource';
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

  public readonly create = injectApi((payment: PaymentForm) => this.#httpClient.post(`/api/payments`, payment));

  public readonly update = injectApi((id: number, payment: PaymentForm) =>
    this.#httpClient.put(`/api/payments/${id}`, payment)
  );

  public createForm() {
    return this.#fb.group({
      created: [null as dateString | null, Validators.required],
      amount: [0, Validators.required],
      person: [null as number | null, Validators.required],
    });
  }

  public search(p: () => SearchQuery | { all: boolean }) {
    return rxResource({
      request: p,
      loader: (params) => {
        const p = toParams(params.request as SearchQuery);
        return this.#httpClient.get<SearchResults<Payment>>('/api/payments', {
          params: p,
        });
      },
    });
  }

  private get(id: number) {
    return this.#httpClient.get<Payment>(`/api/payments/${id}`);
  }

  private delete(id: number) {
    return this.#httpClient.delete(`/api/payments/${id}`);
  }
}
