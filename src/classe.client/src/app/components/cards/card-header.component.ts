import { Component, input } from '@angular/core';

@Component({
  selector: 'app-card-header',
  template: `<div class="card-header">
    <h3 class="card-title">{{ title() }}</h3>
    <div class="card-actions"><ng-content select="div.btn-list"/></div>
  </div>`,
  styles: ':host {display:contents}',
  imports: [],
})
export class CardHeaderComponent {
  public readonly title = input<string | null>(null);
}
