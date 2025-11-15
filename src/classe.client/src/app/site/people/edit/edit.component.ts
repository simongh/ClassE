import { Component, computed, inject, input, output } from '@angular/core';
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
  readonly #router = inject(Router);

  readonly #svc = inject(PersonService);

  public readonly person = input<Person | null>();

  public readonly id = input<number | null>();

  public readonly adding = input<boolean>(false);

  public readonly saved = output();

  protected readonly saving = computed(() => this.#svc.create.isLoading() || this.#svc.update.isLoading());

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
    if (!this.form().valid) {
      return;
    }

    if (this.adding()) {
      this.#svc.create.load({
        payload: [this.form().value],
        subscriber: {
          next: (id) => this.#router.navigateByUrl(`/people/${id}`),
        },
      });
    } else {
      this.#svc.update.load({
        payload: [this.form().value, this.id()!],
        subscriber: {
          next: () => {
            this.saved.emit();
          },
        },
      });
    }
  }
}
