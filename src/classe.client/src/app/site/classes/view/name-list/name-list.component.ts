import { Component, input } from '@angular/core';

import { CardComponent, CardHeaderComponent } from '@components/cards';

import { IdName } from '@api/idname';

@Component({
  selector: 'app-name-list',
  imports: [CardHeaderComponent,CardComponent],
  templateUrl: './name-list.component.html',
  styleUrl: './name-list.component.css',
})
export class NameListComponent {
  public readonly title = input<string>();

  public readonly items = input<IdName[]>();
}
