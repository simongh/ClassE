import { CurrencyPipe } from '@angular/common';
import { Component, computed, inject, numberAttribute, signal } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { injectParams } from 'ngxtension/inject-params';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';

import { PersonService } from '@api/people/person.service';

import { DetailsComponent } from './details/details.component';
import { PaymentsComponent } from './payments/payments.component';
import { EditComponent } from '../edit/edit.component';

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent, CurrencyPipe, CardsModule, PaymentsComponent, DetailsComponent, EditComponent],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  protected readonly id = injectParams('id', { parse: numberAttribute });

  protected readonly adding = computed(() => this.id() === 0);

  protected readonly editing = signal<boolean>(this.adding());

  protected readonly person = inject(PersonService).get(() => this.id()!);

  public saved() {
    this.editing.set(false);
    this.person.reload();
  }

  public edit() {
    this.editing.set(true);
  }
}
