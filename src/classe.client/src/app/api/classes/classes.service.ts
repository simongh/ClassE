import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { of } from 'rxjs';

import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Class } from './class';
import { ClassModel } from './class.model';
import { Summary } from './summary';

@Injectable({
  providedIn: 'root',
})
export class ClassesService {
  readonly #httpClient = inject(HttpClient);

  public search(p: () => SearchQuery) {
    return rxResource({
      params: p,
      stream: (query) => {
        const p = toParams(query.params);
        return this.#httpClient.get<SearchResults<Summary>>('/api/classes', {
          params: p,
        });
      },
    });
    // let p = toParams(query);

    // if (query.all) {
    //   p = p.set('all', query.all);
    // }

    // return this.#httpClient.get<SearchResults<Summary>>('/api/classes', {
    //   params: p,
    // });
  }

  public get(p: () => number) {
    return rxResource({
      params: p,
      stream: (request) => this.#httpClient.get<Class>(`/api/classes/${request.params}`),
    });
  }

  public update(id: number, theClass: ClassModel) {
    return this.#httpClient.put(`/api/classes/${id}`, theClass);
  }

  public create(theClass: ClassModel) {
    return this.#httpClient.post<number>('/api/classes', theClass);
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/classes/${id}`);
  }
}
