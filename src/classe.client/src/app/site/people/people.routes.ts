import { Routes } from '@angular/router';

import { SearchComponent } from './search/search.component';
import { ViewComponent } from './view/view.component';

export default [
  {
    path: '',
    component: SearchComponent,
  },
  {
    path: ':id',
    component: ViewComponent
  }
] as Routes;
