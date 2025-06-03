import { Component } from '@angular/core';

import { PageHeaderComponent } from "@components/page-header/page-header.component";

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {}
