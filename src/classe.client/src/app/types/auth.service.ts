import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { catchError, of, tap } from 'rxjs';

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

  public load(user: UserModel) {
    this.#user.set(user);
  }

  public clear() {
    this.#user.set({} as UserModel);
  }

  public extend() {
    return this.#client.get<UserModel>('/api/auth/token').pipe(
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
