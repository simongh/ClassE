import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { rxResource } from '@angular/core/rxjs-interop';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { withDefaultFilters } from '@app-types/search-query';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';
import { CardsModule } from '@components/cards';
import { VenueService } from '../venue.service';

@Component({
  selector: 'app-search',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #venueSvc = inject(VenueService);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly venues = rxResource({
    request: () => this.qry(),
    loader: (params) => this.#venueSvc.search(params.request),
  });
}
