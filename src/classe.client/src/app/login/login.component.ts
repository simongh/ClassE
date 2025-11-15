import { Component, computed, inject } from '@angular/core';
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

  readonly #router = inject(Router);

  readonly #returnUrl = injectQueryParams((p) => p['returnUrl'] ?? '/');

  protected readonly submitting = computed(() => this.#loginSvc.login.isLoading());

  protected readonly form = this.#loginSvc.createForm();

  public login() {
    this.form.markAllAsTouched();

    if (!this.form.valid) {
      return;
    }

    this.#loginSvc.login.load({
      payload: [this.form.value],
      subscriber: {
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
        },
        error: () => {
          this.form.controls.password.setValue('');
          this.form.markAsUntouched();

          this.#toastSvc.addFailure('Login failed. Please try again later');
        },
      },
    });
  }
}
