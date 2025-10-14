import { Component, DestroyRef, inject, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { PlusIcon } from '@components/svg';
import { ToastService } from '@components/toast/toast.service';
import { ValidatorMessageComponent } from '@components/validator-message/validator-message.component';

import { VenueService } from '@api/venues/venue.service';

@Component({
  selector: 'app-edit-modal',
  imports: [ReactiveFormsModule, PlusIcon, ValidatorMessageComponent],
  templateUrl: './edit-modal.component.html',
  styleUrl: './edit-modal.component.css',
})
export class EditModalComponent {
  readonly #destroyed = inject(DestroyRef);

  readonly #svc = inject(VenueService);

  readonly #toastSvc = inject(ToastService);

  protected readonly modal = inject(NgbActiveModal);

  protected readonly saving = signal(false);

  protected readonly form = this.#svc.createForm();

  protected readonly id = signal<number>(0);

  public load(id: number) {
    if (id === 0) {
      this.resetForm();
    } else {
      this.#svc
        .get(id)
        .pipe(takeUntilDestroyed(this.#destroyed))
        .subscribe((v) => {
          this.id.set(id);

          this.form.setValue(v);
        });
    }
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

          this.#toastSvc.addSuccess('Venue updated');
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
      name: '',
      email: '',
      phone: '',
      address: '',
    });
  }
}
