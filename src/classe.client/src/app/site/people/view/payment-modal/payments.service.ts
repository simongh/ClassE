import { Injectable, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class PaymentsService {
  readonly #fb = inject(FormBuilder);

  public readonly form = this.#fb.group({
    date: ['', Validators.required],
    amount: ['', Validators.required],
  });

  public add() {
    if (this.form.valid) {
      console.log('added', this.form.value);
      this.form.reset();
      return true;
    } else {
      console.log('cancel');
      return false;
    }
  }
}
