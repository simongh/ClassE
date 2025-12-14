import { CurrencyPipe } from '@angular/common';
import { Component, computed, signal } from '@angular/core';

import { CardsModule } from '@components/cards';
import { PageHeaderComponent } from '@components/page-header/page-header.component';

import { Class } from '@api/classes/class';

import { NameListComponent } from './name-list/name-list.component';
import { SessionsComponent } from './sessions/sessions.component';

@Component({
  selector: 'app-view',
  imports: [PageHeaderComponent, CardsModule, CurrencyPipe, NameListComponent, SessionsComponent],
  templateUrl: './view.component.html',
  styleUrl: './view.component.css',
})
export class ViewComponent {
  protected readonly class = signal<Class>({
    id: 1,
    dayOfWeek: 'Monday',
    startTime: '18:00',
    duration: 60,
    isActive: true,
    cost: 5.0,
    bookings: [
      {
        id: 0,
        name: 'client name',
      },
    ],
    waitingList: [],
    venue: {
      id: 0,
      name: 'venue name',
    },
    sessions: [
      {
        id: 0,
        date: '2025-12-01',
        expected: 10,
        attended: 9,
      },
    ],
  });
}
