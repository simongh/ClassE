import { Routes } from '@angular/router';

import { SiteComponent } from './site/site.component';
import { WeatherComponent } from './site/weather/weather.component';

export const routes: Routes = [
  {
    path: '',
    component: SiteComponent,
    children: [
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
    ],
  },
  {
    path: '**',
    loadComponent: () => import('./not-found/not-found.component').then((m) => m.NotFoundComponent),
  },
];
