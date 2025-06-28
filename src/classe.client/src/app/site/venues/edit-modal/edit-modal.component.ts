import { Component, DestroyRef, effect, inject, signal } from '@angular/core';
import { rxResource, takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

import { SvgComponent } from '@components/svg.component';
import { ToastService } from '@components/toast/toast.service';

import { Venue } from '@api/venues/venue';
import { VenueService } from '@api/venues/venue.service';

@Component({
  selector: 'app-edit-modal',
  imports: [ReactiveFormsModule, SvgComponent],
  templateUrl: './edit-modal.component.html',
  styleUrl: './edit-modal.component.css',
})
export class EditModalComponent {
  readonly #destroyed = inject(DestroyRef);

  readonly #svc = inject(VenueService);

  readonly #toastSvc = inject(ToastService);

  readonly #fb = inject(FormBuilder);

  protected readonly modal = inject(NgbActiveModal);

  protected readonly evenu = signal<Venue | null>(null);

  protected readonly saving = signal(false);

  protected readonly form = this.#fb.group({
    name: ['', Validators.required],
    email: ['', Validators.email],
    phone: [''],
    address: [''],
  });

  public readonly id = signal<number>(0);

  protected readonly venue = rxResource({
    request: () => this.id(),
    loader: (p) => this.#svc.get(p.request),
  });

  constructor() {
    effect(() => {
      const venue = this.venue.value();
      if (!venue) {
        return;
      }

      this.form.setValue({
        name: venue.name,
        email: venue.name,
        phone: venue.phone,
        address: venue.address,
      });
    });
  }

  public save() {
    this.form.markAsTouched();
    if (this.form.invalid) {
      return;
    }

    this.saving.set(true);

    const payload = {
      name: this.form.value.name!,
      email: this.form.value.email!,
      phone: this.form.value.phone!,
      address: this.form.value.address!,
    };

    (this.id() === 0 ? this.#svc.create(payload) : this.#svc.update(this.id(), payload))
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
