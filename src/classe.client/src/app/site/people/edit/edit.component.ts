import { Component, effect, inject, input } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { Person } from '@api/people/person';

@Component({
  selector: 'app-edit',
  imports: [ReactiveFormsModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css',
})
export class EditComponent {
  readonly #fb = inject(FormBuilder);

  public readonly person = input<Person>();

  public readonly id = input<number | null>();

  protected readonly form = this.#fb.group({
    firstName: [this.person()?.firstName, Validators.required],
    lastName: [this.person()?.lastName, Validators.required],
    email: [this.person()?.email, [Validators.email]],
    phone: [this.person()?.phone],
    address: [this.person()?.address],
    gender: [this.person()?.gender],
    dateOfBirth: [this.person()?.dateOfBirth],
    occupation: [this.person()?.occupation],
    emergencyContact: [this.person()?.emergencyContact],
    emergencyContactNumber: [this.person()?.emergencyContactNumber],
    notes: [this.person()?.notes],
    consentDate: [this.person()?.consentDate],
  });

  constructor() {
    effect(() => {
      this.form.patchValue(this.person()!);
    });
  }
}
