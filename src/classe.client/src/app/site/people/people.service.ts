import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EMPTY, of } from 'rxjs';
import { SearchResults } from '@app-types/search-results';
import { SearchQuery, toParams } from '@app-types/search-query';
import { Summary } from './summary';
import { Person } from './person';

@Injectable({
  providedIn: 'root',
})
export class PeopleService {
  readonly #httpClient = inject(HttpClient);
  public search(query: SearchQuery) {
    return of<SearchResults<Summary>>({
      total: 0,
      results: [{
        id: 0,
        firstName: 'bob',
        lastName: 'bobson',
        email: 'bob@bobson.int',
        phone: null
      }],
    });
    const p = toParams(query);
    return this.#httpClient.get<SearchResults<Summary>>('/api/people', {
      params: p,
    });
  }

  public get(id: number) {
    return of<Person>({
      firstName: '',
      lastName: '',
      email: null,
      phone: null,
      classBalance: 0,
      bookings: [],
      waitingList: [],
      payments: [],
    });
    return this.#httpClient.get<Person>(`/api/people/${id}`);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/people/${id}`);
  }

  public update(id: number, person: { firstName: string }) {
    return EMPTY;
  }

  public create(person: { firstName: string }) {
    return this.#httpClient.post<number>('/api/people', person);
  }
}
