import { Component, inject } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { PlusIcon } from '@components/svg';

import { PaymentsService } from './payments.service';

@Component({
  selector: 'app-payment-modal',
  imports: [ReactiveFormsModule, PlusIcon],
  templateUrl: './payment-modal.component.html',
  styleUrl: './payment-modal.component.css',
})
export class PaymentModalComponent {
  readonly #svc = inject(PaymentsService);

  protected readonly modal = inject(NgbActiveModal);

  protected get form() {
    return this.#svc.form;
  }

  protected add() {
    this.#svc.add();
    this.modal.close();
  }
}
