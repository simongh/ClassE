import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';
import { Summary } from './summary';
import { of } from 'rxjs';
import { Class } from './class';
import { dateString } from '@app-types/dateString';

@Injectable({
  providedIn: 'root',
})
export class ClassesService {
  readonly #httpClient = inject(HttpClient);

  public search(query: { all: boolean } & SearchQuery) {
    return of<SearchResults<Summary>>({
      total: 41,
      results: [{
        id: 0,
        startDate: '2025-05-01',
        endDate: '2025-06-01',
        startTime: 18,
        duration: 60,
        dayOfWeek: 'Thursday',
        booked: 5,
        waiting: 5,
        venue: {
          id: 0,
          name: ' the hall'
        }
      }],
    });
    let p = toParams(query);

    if (query.all) {
      p = p.set('all', query.all);
    }

    return this.#httpClient.get<SearchResults<Summary>>('/api/classes', {
      params: p,
    });
  }

  public get(id: number) {
    return this.#httpClient.get<Class>(`/api/classes/${id}`);
  }

  public update(id: number, theClass: { startDate: dateString }) {
    return this.#httpClient.put(`/api/classes/${id}`, theClass);
  }

  public create(theClass: { startDate: dateString }) {
    return this.#httpClient.post<number>('/api/classes', theClass);
  }

  public delete(id: number){
    return this.#httpClient.delete(`/api/classes/${id}`);
  }
}
