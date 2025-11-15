import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { NonNullableFormBuilder, Validators } from '@angular/forms';

import { injectApi } from '@app-types/ApiResource';
import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Summary } from './summary';
import { Venue } from './venue';

export type VenueForm = ReturnType<VenueService['createForm']>['value'];

@Injectable({
  providedIn: 'root',
})
export class VenueService {
  readonly #httpClient = inject(HttpClient);

  readonly #fb = inject(NonNullableFormBuilder);

  public readonly createOrUpdate = injectApi((id: number, venue: VenueForm) => {
    if (id === 0) {
      return this.#httpClient.post<number>('/api/venues', venue);
    } else {
      return this.#httpClient.put<number>(`/api/venues/${id}`, venue);
    }
  });

  public readonly delete = injectApi((id: number) => this.#httpClient.delete(`/api/venues/${id}`));

  public createForm() {
    return this.#fb.group({
      name: ['', Validators.required],
      email: ['' as string | null, Validators.email],
      phone: ['' as string | null],
      address: ['' as string | null],
    });
  }

  public search(p: () => SearchQuery) {
    return rxResource({
      request: p,
      loader: (params) => {
        const p = toParams(params.request);
        return this.#httpClient.get<SearchResults<Summary>>('/api/venues', { params: p });
      },
    });
  }

  public get(id: number) {
    return this.#httpClient.get<Venue>(`/api/venues/${id}`);
  }
}
