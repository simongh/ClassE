import { CurrencyPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { RouterLink } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';
import { PagerComponent } from '@components/pager/pager.component';
import { SorterComponent } from '@components/sorter/sorter.component';

import { Payment } from '@api/payments/payment';
import { PaymentsService } from '@api/payments/payments.service';
import { withDefaultFilters } from '@app-types/search-query';

import { PaymentModalComponent } from './payment-modal/payment-modal.component';

@Component({
  selector: 'app-payments',
  imports: [CardsModule, PageHeaderComponent, SorterComponent, PagerComponent, RouterLink, CurrencyPipe],
  templateUrl: './payments.component.html',
  styleUrl: './payments.component.css',
})
export class PaymentsComponent {
  readonly #paymentsSvc = inject(PaymentsService);

  readonly #modelSvc = inject(NgbModal);

  protected readonly qry = injectQueryParams((p) => withDefaultFilters(p));

  protected readonly payments = rxResource({
    request: () => {
      return { ...this.qry(), all: false };
    },
    loader: (params) => this.#paymentsSvc.search(params.request),
  });

  protected open(payment: Payment | null) {
    const modal = this.#modelSvc.open(PaymentModalComponent).componentInstance;

    if (payment == null) {
      modal.reset();
    } else {
      modal.load(payment);
    }
  }
}
