import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';

import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { SearchQuery } from '@app-types/search-query';
import { PeopleService } from '../people.service';

@Component({
  selector: 'app-people',
  imports: [PageHeaderComponent, RouterLink],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #peopleSvc = inject(PeopleService);

  protected readonly people = rxResource({
    request: ()=> new SearchQuery(),
    loader: (params) => this.#peopleSvc.search(params.request),
  });
}
