import { Component } from '@angular/core';
import { SvgComponent } from '../svg.component';
import { NavItemComponent } from './nav-item.component';

@Component({
  selector: 'app-sidebar',
  imports: [SvgComponent, NavItemComponent],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent {}
