import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { ApiResourceRef, injectApi } from '@app-types/ApiResource';
import { UserModel } from '@app-types/auth.service';

export type LoginForm = ReturnType<LoginService['createForm']>['value'];

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  readonly #client = inject(HttpClient);

  readonly #fb = inject(FormBuilder);

  public readonly login = injectApi((form: LoginForm) => this.#client.post<UserModel>('/api/auth/login', form));

  public createForm() {
    return this.#fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
}
