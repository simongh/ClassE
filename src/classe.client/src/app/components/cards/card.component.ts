import { Component } from '@angular/core';

@Component({
    selector:'app-card',
    template: '<div class="card"><ng-content/></div>'
})
export class CardComponent
{}