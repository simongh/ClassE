import { DatePipe } from '@angular/common';
import { Component, input } from '@angular/core';

import { Person } from '@api/people/person';

@Component({
  selector: 'app-more-details',
  imports: [DatePipe],
  templateUrl: './more-details.component.html',
  styleUrl: './more-details.component.css',
})
export class MoreDetailsComponent {
  public readonly person = input<Person>();
}
