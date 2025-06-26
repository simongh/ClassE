import { Component, DestroyRef, inject, input, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { PersonListComponent } from '@components/person-list/person-list.component';
import { SvgComponent } from '@components/svg.component';
import { ToastService } from '@components/toast/toast.service';

import { Payment } from '@api/payments/payment';
import { PaymentsService } from '@api/payments/payments.service';
import { dateString } from '@app-types/dateString';

@Component({
  selector: 'app-payment-modal',
  imports: [ReactiveFormsModule, SvgComponent, PersonListComponent],
  templateUrl: './payment-modal.component.html',
  styleUrl: './payment-modal.component.css',
})
export class PaymentModalComponent {
  readonly #svc = inject(PaymentsService);

  readonly #toastSvc = inject(ToastService);

  readonly #fb = inject(FormBuilder);

  readonly #destroyed = inject(DestroyRef);

  protected readonly form = this.#fb.group({
    date: [null as dateString | null, Validators.required],
    amount: [0, Validators.required],
    person: [0],
  });

  protected readonly saving = signal(false);

  protected readonly modal = inject(NgbActiveModal);

  protected id = signal(0);

  public load(payment: Payment) {
    this.id.set(payment.id);

    this.form.setValue({
      date: payment?.date,
      amount: payment?.amount,
      person: payment?.person.id,
    });
  }

  protected save() {
    this.form.markAsTouched();
    if (this.form.invalid) {
      return;
    }

    this.saving.set(true);

    const payload = {
      date: this.form.value.date!,
      amount: this.form.value.amount!,
      person: this.form.value.person!,
    };

    (this.id() === 0 ? this.#svc.create(payload) : this.#svc.update(this.id(), payload))
      .pipe(takeUntilDestroyed(this.#destroyed))
      .subscribe({
        next: () => {
          this.resetForm();
          this.saving.set(false);
          this.modal.close();

          this.#toastSvc.addSuccess('Payment updated');
        },
      });
  }

  protected close() {
    this.resetForm();
    this.modal.close();
  }

  private resetForm() {
    this.id.set(0);

    this.form.setValue({
      date: null,
      amount: 0,
      person: 0,
    });
  }
}
