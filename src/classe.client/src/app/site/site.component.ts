import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { SidebarComponent } from '@components/sidebar/sidebar.component';
import { ToastComponent } from '@components/toast/toast.component';

@Component({
  selector: 'app-site',
  imports: [SidebarComponent, RouterOutlet, ToastComponent],
  templateUrl: './site.component.html',
  styleUrl: './site.component.css',
})
export class SiteComponent {}
