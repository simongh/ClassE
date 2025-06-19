import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { DEFAULT_CURRENCY_CODE } from '@angular/core';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';

import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    { provide: DEFAULT_CURRENCY_CODE, useValue: 'GBP' },
  ],
});
