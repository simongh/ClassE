import { Component, inject, input } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

import { PersonService } from '@api/people/person.service';

@Component({
  selector: 'app-person-list',
  imports: [ReactiveFormsModule],
  template: `<select class="form-select" [formControl]="control()">
    <option [value]="null" disabled></option>
    @for (item of people(); track item) {
    <option [value]="item.id">{{ item.name }}</option>
    }
  </select>`,
})
export class PersonListComponent {
  readonly #svc = inject(PersonService);

  public readonly control = input.required<FormControl<number | null>>();

  protected readonly people = toSignal(this.#svc.list());
}
