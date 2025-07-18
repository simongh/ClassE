import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, inject, numberAttribute } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { injectParams } from 'ngxtension/inject-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';

import { PersonService } from '@api/people/person.service';

import { DetailsComponent } from './details/details.component';
import { PaymentModalComponent } from './payment-modal/payment-modal.component';
import { PaymentsComponent } from './payments/payments.component';

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent, DatePipe, CurrencyPipe, CardsModule, PaymentsComponent, DetailsComponent],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  readonly #svc = inject(PersonService);

  readonly #modalSvc = inject(NgbModal)

  protected readonly id = injectParams('id', { parse: numberAttribute });

  protected readonly person = rxResource({
    request: () => this.id()!,
    loader: (params) => this.#svc.get(params.request),
  });

  public open(){
    this.#modalSvc.open(PaymentModalComponent);
  }
}
