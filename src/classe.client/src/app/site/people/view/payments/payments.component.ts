import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, inject, input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { CardsModule } from '@components/cards';

import { PaymentModel } from '@api/payments/payment.model';

import { PaymentModalComponent } from '../payment-modal/payment-modal.component';

@Component({
  selector: 'app-payments',
  imports: [DatePipe, CurrencyPipe, CardsModule],
  templateUrl: './payments.component.html',
  styleUrl: './payments.component.css',
})
export class PaymentsComponent {
  readonly #modalSvc = inject(NgbModal);

  public readonly payments = input<Payment[]>();

    public open(){
      this.#modalSvc.open(PaymentModalComponent);
    }
  
}

type Payment = {
  id: number;
} & PaymentModel;
