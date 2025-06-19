import { Routes } from '@angular/router';

import { WeatherComponent } from './site/weather/weather.component';

export const routes: Routes = [
  {
    path: '',
    component: WeatherComponent,
  },
  {
    path: 'people',
    loadChildren: () => import('./site/people/people.routes'),
  },
  {
    path: 'venues',
    loadChildren: () => import('./site/venues/venue.routes'),
  },
  {
    path: 'classes',
    loadChildren: () => import('./site/classes/classes.routes'),
  },
  {
    path: 'payments',
    loadChildren: () => import('./site/payments/payment.routes'),
  },
];
