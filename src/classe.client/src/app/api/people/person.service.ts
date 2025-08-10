import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { EMPTY, of } from 'rxjs';

import { IdName } from '@api/idname';
import { SearchQuery } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Person } from './person';
import { PersonModel } from './person.model';
import { Summary } from './summary';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
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
      id: 0,
      firstName: 'Simon',
      lastName: 'Halsey',
      email: 'simon@thehalseys.uk',
      address: 'line 1\nline 2\npost code',
      dateOfBirth: '1990-01-01',
      gender: 'Male',
      occupation: 'software engineer',
      emergencyContact: 'Emma Halsey',
      emergencyContactNumber: '0898 505050',
      phone: null,
      notes: 'some notes',
      consentDate: '2025-07-14',
      joiningQuestions: null,
      balance: 0,
      bookings: [],
      waitingList: [],
      payments: [
        {
          id: 0,
          date: '2025-05-01',
          amount: 10.0,
        },
      ],
    });
    // return this.#httpClient.get<Person>(`/api/people/${id}`);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/people/${id}`);
  }

  public update(id: number, person: PersonRequest) {
    return of(null);
    //return this.#httpClient.put(`/api/people/${id}`,person);
  }

  public create(person: PersonRequest) {
    return this.#httpClient.post<number>('/api/people', person);
  }

  public list() {
    return of<IdName[]>([
      {
        id: 1,
        name: 'first name'
      }
    ])
    //return this.#httpClient.get<IdName>('/api/people/list');
  }
}

type PersonRequest = PersonModel
