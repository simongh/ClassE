import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, DestroyRef, inject, input, model, output } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaymentModalComponent } from 'app/site/payments/payment-modal/payment-modal.component';
import { switchMap } from 'rxjs';

import { CardsModule } from '@components/cards';

import { PaymentModel } from '@api/payments/payment.model';
import { PersonService } from '@api/people/person.service';

@Component({
  selector: 'app-payments',
  imports: [DatePipe, CurrencyPipe, CardsModule],
  templateUrl: './payments.component.html',
  styleUrl: './payments.component.css',
})
export class PaymentsComponent {
  readonly #modalSvc = inject(NgbModal);

  readonly #destroyed = inject(DestroyRef);

  readonly #personSvc = inject(PersonService);

  public readonly payments = model<PaymentModel[]>();

  public readonly person = input<number>();

  public add() {
    const modal = this.showModal();
    modal.componentInstance.resetForm(this.person());
  }

  public open(payment: PaymentModel) {
    const modal = this.showModal();

    modal.componentInstance.load(payment, this.person());
  }

  private showModal() {
    const modal = this.#modalSvc.open(PaymentModalComponent);

    modal.componentInstance.showPersonPicker.set(false);
    modal.closed
      .pipe(
        takeUntilDestroyed(this.#destroyed),
        switchMap(() => {
          return this.#personSvc.payments(this.person()!);
        })
      )
      .subscribe((p) => {
        this.payments.set(p.results);
      });

    return modal;
  }
}
