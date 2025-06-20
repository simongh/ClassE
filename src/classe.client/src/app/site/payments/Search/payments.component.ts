import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';

import { withDefaultFilters } from '@app-types/search-query';

import { PaymentsService } from '../payments.service';

@Component({
  selector: 'app-payments',
  imports: [CardsModule, PageHeaderComponent, SorterComponent, PagerComponent, RouterLink],
  templateUrl: './payments.component.html',
  styleUrl: './payments.component.css',
})
export class PaymentsComponent {
  readonly #paymentsSvc = inject(PaymentsService);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly payments = rxResource({
    request: () => {
      return { ...this.qry(), all: false };
    },
    loader: (params) => this.#paymentsSvc.search(params.request),
  });
}
