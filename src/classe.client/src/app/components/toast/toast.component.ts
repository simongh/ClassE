import { Component, inject } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

import { ToastService } from './toast.service';

@Component({
  selector: 'app-toast',
  imports: [NgbToastModule],
  template: `@for (toast of toastSvc.toasts; track toast) {<ngb-toast
      [className]="toast.class"
      [autohide]="true"
      [delay]="5000"
      (hidden)="toastSvc.remove(toast)"
      >{{ toast.message }}</ngb-toast
    >}`,
  host: { class: 'toast-container position-fixed top-0 end-0 p-3', style: 'z-index: 1200' },
})
export class ToastComponent {
  protected readonly toastSvc = inject(ToastService);
}
