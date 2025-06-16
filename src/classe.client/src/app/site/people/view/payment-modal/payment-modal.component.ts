import { Component, ElementRef, inject, viewChild } from '@angular/core';
import { PaymentsService } from './payments.service';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-payment-modal',
  imports: [ReactiveFormsModule],
  templateUrl: './payment-modal.component.html',
  styleUrl: './payment-modal.component.css',
})
export class PaymentModalComponent {
  readonly #svc = inject(PaymentsService);

  readonly #elementRef = inject(ElementRef);

    protected get form() {
    return this.#svc.form;
  }

  protected add() {
    //this.#svc.add();
    this.#elementRef.nativeElement.querySelector('#paymentModal').hide();
  }
}
