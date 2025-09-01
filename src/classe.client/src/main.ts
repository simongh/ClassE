import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { DEFAULT_CURRENCY_CODE } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { authInterceptor } from '@app-types/auth.interceptor';

import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptors([authInterceptor])),
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'GBP' },
  ],
});
