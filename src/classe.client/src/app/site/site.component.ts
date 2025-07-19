import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { SidebarComponent } from '@components/sidebar/sidebar.component';

@Component({
  selector: 'app-site',
  imports: [SidebarComponent, RouterOutlet],
  templateUrl: './site.component.html',
  styleUrl: './site.component.css',
})
export class SiteComponent {}
