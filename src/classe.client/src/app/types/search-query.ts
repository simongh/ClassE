import { HttpParams } from '@angular/common/http';

export class SearchQuery {
  public offset: number | null = null;
  public limit: number | null = null;
}

export const toParams = (query: SearchQuery) => {
  let p = new HttpParams();

  if (query.limit) {
    p = p.set('limit', query.limit);
  }

  if (query.offset) {
    p = p.set('offset', query.offset);
  }

  return p;
};
