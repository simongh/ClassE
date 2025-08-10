import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, DestroyRef, inject, numberAttribute, signal } from '@angular/core';
import { rxResource, takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { injectParams } from 'ngxtension/inject-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';

import { PersonService } from '@api/people/person.service';

import { DetailsComponent } from './details/details.component';
import { PaymentModalComponent } from './payment-modal/payment-modal.component';
import { PaymentsComponent } from './payments/payments.component';
import { EditComponent } from '../edit/edit.component';

@Component({
  selector: 'app-view',
  imports: [
    PageHeaderComponent,
    DatePipe,
    CurrencyPipe,
    CardsModule,
    PaymentsComponent,
    DetailsComponent,
    EditComponent,
  ],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  readonly #svc = inject(PersonService);

  readonly #modalSvc = inject(NgbModal);

  readonly #destroyed = inject(DestroyRef);

  protected readonly id = injectParams('id', { parse: numberAttribute });

  protected readonly person = rxResource({
    request: () => this.id()!,
    loader: (params) => this.#svc.get(params.request),
  });

  protected readonly editing = signal<boolean>(false);

  protected readonly saving = signal(false);

  public open() {
    this.#modalSvc.open(PaymentModalComponent);
  }

  protected edit(active: boolean) {
    this.editing.set(active);
  }

  protected save() {
    this.saving.set(true);

    this.#svc
      .update(this.id()!, {
        ...this.person.value()!,
        notes: 'xxxx',
      })
      .pipe(takeUntilDestroyed(this.#destroyed))
      .subscribe(() => {
        this.editing.set(false);
        this.saving.set(false);
        this.person.reload();
      });
  }
}
