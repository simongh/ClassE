import { Component } from '@angular/core';

@Component({
  selector: 'app-card-footer',
  template: `<div class="card-footer">
    <div class="row g-2 justify-content-center justify-content-sm-between">
      <div class="col-auto align-items-center">
        <p class="m-0 text-secondary">
          <ng-content />
        </p>
      </div>
      <div class="col-auto">
        <ng-content select="app-pager" />
      </div>
    </div>
  </div>`,
})
export class CardFooterComponent {}
