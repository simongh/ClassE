import { Component, DestroyRef, inject, signal } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { injectQueryParams } from 'ngxtension/inject-query-params';

import { CardComponent } from '@components/cards';
import { ToastService } from '@components/toast/toast.service';

import { LoginService } from '@api/login/login.service';
import { AuthService } from '@app-types/auth.service';

@Component({
  selector: 'app-login',
  imports: [CardComponent, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  readonly #loginSvc = inject(LoginService);

  readonly #authSvc = inject(AuthService);

  readonly #toastSvc = inject(ToastService);

  readonly #destroyed = inject(DestroyRef);

  readonly #router = inject(Router);

  readonly #returnUrl = injectQueryParams((p) => p['returnUrl'] ?? '/');

  protected readonly submitting = signal(false);

  protected readonly form = this.#loginSvc.createForm();

  public login() {
    this.form.markAllAsTouched();

    if (!this.form.valid) {
      return;
    }

    this.submitting.set(true);
    this.#loginSvc
      .login(this.form.value)
      .pipe(takeUntilDestroyed(this.#destroyed))
      .subscribe({
        next: (u) => {
          this.#authSvc.clear();

          if (u.success) {
            this.#authSvc.load(u);

            this.#router.navigateByUrl(this.#returnUrl());
          } else {
            this.form.controls.password.setValue('');
            this.form.markAsUntouched();

            this.#toastSvc.addFailure('Login failed. Please try again later');
          }

          this.submitting.set(false);
        },
        error: () => {
          this.form.controls.password.setValue('');
          this.form.markAsUntouched();

          this.submitting.set(false);

          this.#toastSvc.addFailure('Login failed. Please try again later');
        },
      });
  }
}
