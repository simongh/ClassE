import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';

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

  public createForm() {
    return this.#fb.group({
      name: ['', Validators.required],
      email: ['' as string | null, Validators.email],
      phone: ['' as string | null],
      address: ['' as string | null],
    });
  }

  public search(query: SearchQuery) {
    const p = toParams(query);
    return this.#httpClient.get<SearchResults<Summary>>('/api/venues', {
      params: p,
    });
  }

  public get(id: number) {
    return this.#httpClient.get<Venue>(`/api/venues/${id}`);
  }

  public update(id: number, venue: VenueForm) {
    return this.#httpClient.put<number>(`/api/venues/${id}`, venue);
  }

  public create(venue: VenueForm) {
    return this.#httpClient.post<number>('/api/venues', venue);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/venues/${id}`);
  }
}
