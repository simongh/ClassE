import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';

import { withDefaultFilters } from '@app-types/search-query';

import { ClassesService } from '../classes.service';

@Component({
  selector: 'app-search',
  imports: [PageHeaderComponent, RouterLink, PagerComponent, SorterComponent, CardsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
})
export class SearchComponent {
  readonly #classSvc = inject(ClassesService);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly classes = rxResource({
    request: () => {
      return { ...this.qry(), all: false };
    },
    loader: (params) => this.#classSvc.search(params.request),
  });
}
