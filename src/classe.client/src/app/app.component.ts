import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { SidebarComponent } from '@components/sidebar/sidebar.component';
import { ToastComponent } from '@components/toast/toast.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet, SidebarComponent, ToastComponent],
})
export class AppComponent {}
