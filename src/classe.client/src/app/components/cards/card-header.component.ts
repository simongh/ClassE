import { Component, input } from '@angular/core';

@Component({
  selector: 'app-card-header',
  template: `<div class="card-header">
    <div class="row w-full">
      <div class="col">
        <h3 class="card-title">{{ title() }}</h3>
      </div>
      <div class="col-md-auto">
        <ng-content select="div.btn-list" />
      </div>
    </div>
  </div>`,
  styles: ':host {display:contents}',
  imports: [],
})
export class CardHeaderComponent {
  public readonly title = input<string | null>(null);
}
