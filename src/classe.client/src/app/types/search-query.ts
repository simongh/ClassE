import { HttpParams } from '@angular/common/http';
import { signal } from '@angular/core';
import { Params } from '@angular/router';

export class SearchQuery {
  public offset: number | null = null;
  public limit: number | null = null;
  public sortBy: string | null = null;
  public dir: 'asc' | 'desc'| null = null;
}

export const toParams = (query: SearchQuery) => {
  let p = new HttpParams()
    .set('limit', query.limit ?? 20)
    .set('offset', query.offset?? 0);
  
  if (query.sortBy) {
    p = p.append('sortBy',query.sortBy);

    if (query.dir) {
      p = p.append('dir',query.dir);
    }
  }

  return p;
};

export const withDefaultFilters = (p: Params): SearchQuery => ({
  offset: p['offset'] ? +p['offset'] : null,
  limit: p['limit'] ? +p['limit'] : null,
  dir: p['dir'] === 'desc' ? 'desc' : null,
  sortBy: p['sortBy'],
});
