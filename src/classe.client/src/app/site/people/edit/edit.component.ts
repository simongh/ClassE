import { Component, computed, DestroyRef, inject, input, output, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';

import { CalendarIcon } from '@components/svg';
import { ValidatorMessageComponent } from '@components/validator-message/validator-message.component';

import { Person } from '@api/people/person';
import { PersonService } from '@api/people/person.service';


@Component({
  selector: 'app-edit',
  imports: [ReactiveFormsModule, ValidatorMessageComponent, NgbInputDatepicker, CalendarIcon],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css',
})
export class EditComponent {
  readonly #destroyed = inject(DestroyRef);

  readonly #router = inject(Router);

  readonly #svc = inject(PersonService);

  public readonly person = input<Person | null>();

  public readonly id = input<number | null>();

  public readonly adding = input<boolean>(false);

  public readonly saved = output();

  protected readonly saving = signal(false);

  protected readonly form = computed(() => this.#svc.form(this.person()));

  protected cancel() {
    if (this.adding()) {
      this.#router.navigateByUrl('/people');
    } else {
      this.saved.emit();
    }
  }

  protected save() {
    this.form().markAllAsTouched();
    if (!this.form().valid) return;

    this.saving.set(true);

    if (this.adding()) {
      this.#svc
        .create({ ...this.form().value })
        .pipe(takeUntilDestroyed(this.#destroyed))
        .subscribe((id) => {
          this.#router.navigateByUrl(`/people/${id}`);
        });
    } else {
      this.#svc
        .update(this.id()!, this.form().value)
        .pipe(takeUntilDestroyed(this.#destroyed))
        .subscribe(() => {
          this.saving.set(false);
          this.saved.emit();
        });
    }
  }
}
