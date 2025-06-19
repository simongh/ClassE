import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { of } from 'rxjs';

import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Summary } from './summary';

@Injectable({
  providedIn: 'root',
})
export class PaymentsService {
  readonly #httpClient = inject(HttpClient);

  public search(query: SearchQuery) {
    return of<SearchResults<Summary>>({
      total: 0,
      results: [{
        date: '2025-06-01',
        amount: 10,
        credits: 5,
        person: {
          id: 0,
          name: 'Simon Halsey'
        }
      }],
    });
    // const p = toParams(query);
    // return this.#httpClient.get<SearchResults<Summary>>('/api/venues', {
    //   params: p,
    // });
  }
}
