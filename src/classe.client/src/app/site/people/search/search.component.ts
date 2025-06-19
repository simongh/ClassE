import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';

import { withDefaultFilters } from '@app-types/search-query';

import { PeopleService } from '../people.service';

@Component({
  selector: 'app-people',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #peopleSvc = inject(PeopleService);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly people = rxResource({
    request: () => this.qry(),
    loader: (params) => this.#peopleSvc.search(params.request),
  });
}
