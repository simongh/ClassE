import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { SearchResults } from '@app-types/search-results';
import { Summary } from './summary';
import { of } from 'rxjs';
import { Venue } from './venue';
import { SearchQuery, toParams } from '@app-types/search-query';

@Injectable({
  providedIn: 'root',
})
export class VenueService {
  readonly #httpClient = inject(HttpClient);

  public search(query: SearchQuery) {
    return of<SearchResults<Summary>>({
      total: 0,
      results: [{
        id: 0,
        name: 'the hall',
        email: null,
        phone: null,
      }],
    });
    const p = toParams(query);
    return this.#httpClient.get<SearchResults<Summary>>('/api/venues', {
      params: p,
    });
  }

  public get(id: number) {
    return this.#httpClient.get<Venue>(`/api/venues/${id}`);
  }

  public update(id: number, venue: Venue) {
    return this.#httpClient.put(`/api/venues/${id}`, venue);
  }

  public create(venue: Venue) {
    return this.#httpClient.post<number>('/api/venues', venue);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/venues/${id}`);
  }
}
