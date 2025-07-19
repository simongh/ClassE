import { Component } from '@angular/core';

import { BuildingsIcon, CalendarWeekIcon, CoinPoundIcon, HomeIcon, UsersIcon } from '@components/svg';

import { NavItemComponent } from './nav-item.component';

@Component({
  selector: 'app-sidebar',
  imports: [NavItemComponent, HomeIcon, UsersIcon, CalendarWeekIcon, BuildingsIcon, CoinPoundIcon],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent {}
