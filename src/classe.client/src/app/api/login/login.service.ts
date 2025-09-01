import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { UserModel } from '@app-types/auth.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  readonly #client = inject(HttpClient);

  readonly #fb = inject(FormBuilder);

  public form = this.#fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  public login() {
    return this.#client.post<UserModel>('/api/auth/login', this.form.value);
  }
}
