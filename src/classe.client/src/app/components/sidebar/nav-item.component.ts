import { Component, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav-item',
  template: `<li class="nav-item" routerLinkActive="active" [routerLinkActiveOptions]="{ exact: exact() }">
    <a class="nav-link" [routerLink]="link()" routerLinkActive="active" [routerLinkActiveOptions]="{ exact: exact() }">
      <span class="nav-link-icon"><ng-content select="svg" /></span>
      <span class="nav-link-title"><ng-content /></span>
    </a>
  </li>`,
  imports: [RouterLink, RouterLinkActive],
})
export class NavItemComponent {
  public readonly link = input.required<string>();

  public readonly exact = input(false);
}
