import { Component, DestroyRef, inject, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbActiveModal, NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';

import { PersonListComponent } from '@components/person-list/person-list.component';
import { PlusIcon, CalendarIcon } from '@components/svg';
import { ToastService } from '@components/toast/toast.service';
import { ValidatorMessageComponent } from '@components/validator-message/validator-message.component';

import { PaymentModel } from '@api/payments/payment.model';
import { PaymentsService } from '@api/payments/payments.service';

@Component({
  selector: 'app-payment-modal',
  imports: [ReactiveFormsModule, PersonListComponent, PlusIcon, ValidatorMessageComponent, NgbInputDatepicker, CalendarIcon],
  templateUrl: './payment-modal.component.html',
  styleUrl: './payment-modal.component.css',
})
export class PaymentModalComponent {
  readonly #svc = inject(PaymentsService);

  readonly #toastSvc = inject(ToastService);

  readonly #destroyed = inject(DestroyRef);

  protected readonly form = this.#svc.createForm();

  protected readonly saving = signal(false);

  protected readonly modal = inject(NgbActiveModal);

  protected id = signal(0);

  public readonly showPersonPicker = signal(true);

  public load(payment: PaymentModel, person: number) {
    this.id.set(payment.id);

    this.form.setValue({
      created: payment?.created,
      amount: payment?.amount,
      person: person,
    });
  }

  protected save() {
    this.form.markAllAsTouched();
    if (this.form.invalid) {
      return;
    }

    this.saving.set(true);

    (this.id() === 0 ? this.#svc.create(this.form.value) : this.#svc.update(this.id(), this.form.value))
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

  private resetForm(person?: number) {
    this.id.set(0);

    this.form.setValue({
      created: null,
      amount: 0,
      person: !person ? null : person,
    });
  }
}
