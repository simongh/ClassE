import { HttpClient, HttpContext } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { catchError, of, tap } from 'rxjs';

import { BYPASS_TOKEN } from './auth.interceptor';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  readonly #client = inject(HttpClient);

  readonly #user = signal({} as UserModel);

  public readonly token = computed(() => this.#user().token);

  public readonly expires = computed(() => this.#user().expires);

  public readonly isAdmin = computed(() => this.#user().isAdmin);

  public readonly isUserLoggedIn = computed(() => !!this.token());

  public needsExtending() {
    const value = this.#user().expires;

    if (!value) {
      return true;
    }

    return new Date(value).valueOf() - Date.now() < 60000;
  }

  public load(user: UserModel) {
    this.#user.set(user);
  }

  public clear() {
    this.#user.set({} as UserModel);
  }

  public extend() {
    return this.#client
      .get<UserModel>('/api/auth/token', {
        context: new HttpContext().set(BYPASS_TOKEN, true),
      })
      .pipe(
        catchError((e) => of(null)),
        tap((u) => this.#user.set(u ?? ({} as UserModel)))
      );
  }
}

export interface UserModel {
  token: string | null;
  expires: Date | null;
  isAdmin: boolean;
  success: boolean;
}
