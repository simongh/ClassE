import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { EMPTY, of } from 'rxjs';

import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Person } from './person';
import { Summary } from './summary';

@Injectable({
  providedIn: 'root',
})
export class PeopleService {
  readonly #httpClient = inject(HttpClient);

  public search(query: SearchQuery) {
    return of<SearchResults<Summary>>({
      total: 0,
      results: [
        {
          id: 0,
          firstName: 'bob',
          lastName: 'bobson',
          email: 'bob@bobson.int',
          phone: null,
        },
      ],
    });
    // const p = toParams(query);
    // return this.#httpClient.get<SearchResults<Summary>>('/api/people', {
    //   params: p,
    // });
  }

  public get(id: number) {
    return of<Person>({
      firstName: 'Simon',
      lastName: 'Halsey',
      email: 'simon@thehalseys.uk',
      phone: null,
      credits: 0,
      bookings: [],
      waitingList: [],
      payments: [
        {
          id: 0,
          created: '2025-05-01',
          amount: 10.00,
          classes: 5
        }
      ],
    });
    // return this.#httpClient.get<Person>(`/api/people/${id}`);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/people/${id}`);
  }

  // eslint-disanpmble-next-line @typescript-eslint/no-unused-vars
  public update(id: number, person: { firstName: string }) {
    return EMPTY;
  }

  public create(person: { firstName: string }) {
    return this.#httpClient.post<number>('/api/people', person);
  }
}
