import { Component } from '@angular/core';
import { CardsModule } from '@components/cards';

import { PageHeaderComponent } from '@components/page-header/page-header.component';

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent, CardsModule],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {}
