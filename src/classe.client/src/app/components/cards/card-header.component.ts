import { Component, input } from '@angular/core';
import { CardTitleComponent } from './card-title.component';

@Component({
  selector: 'app-card-header',
  template: `<div class="card-header">
    @if (!!title()) {
    <app-card-title [title]="title()!" />
    }
    <ng-content />
  </div>`,
  styles: ':host {display:contents}',
  imports: [CardTitleComponent],
})
export class CardHeaderComponent {
  public readonly title = input<string | null>(null);
}
