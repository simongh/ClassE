import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';
import { SvgComponent } from '@components/svg.component';

import { PersonService } from '@api/people/person.service';
import { withDefaultFilters } from '@app-types/search-query';


@Component({
  selector: 'app-people',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule, SvgComponent],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #peopleSvc = inject(PersonService);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly people = rxResource({
    request: () => this.qry(),
    loader: (params) => this.#peopleSvc.search(params.request),
  });
}
