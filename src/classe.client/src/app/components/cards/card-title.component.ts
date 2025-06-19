import { Component, input } from '@angular/core';

@Component({
  selector: 'app-card-title',
  template: `<div class="row w-full">
    <div class="col">
      <h3 class="card-title">{{ title() }}</h3>
    </div>
    <div class="col-md-auto">
      <div class="btn-list">
        <ng-content />
      </div>
    </div>
  </div>`,
  styles:':host { display: contents }'
})
export class CardTitleComponent {
  public readonly title = input.required<string>();
}
