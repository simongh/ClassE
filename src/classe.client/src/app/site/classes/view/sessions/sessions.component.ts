import { DatePipe } from '@angular/common';
import { Component, input } from '@angular/core';

import { CardComponent, CardHeaderComponent } from '@components/cards';

import { SessionSummary } from '@api/classes/session-summary';

@Component({
  selector: 'app-sessions',
  imports: [CardHeaderComponent, CardComponent, DatePipe],
  templateUrl: './sessions.component.html',
  styleUrl: './sessions.component.css',
})
export class SessionsComponent {
  public readonly items = input<SessionSummary[]>();
}
