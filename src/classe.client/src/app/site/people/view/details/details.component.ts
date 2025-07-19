import { DatePipe } from '@angular/common';
import { Component, input } from '@angular/core';

import { Person } from '@api/people/person';

@Component({
  selector: 'app-details',
  imports: [DatePipe],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css',
})
export class DetailsComponent {
  public readonly person = input<Person>();
}
