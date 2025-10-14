import { Component, input, signal } from '@angular/core';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';

import { Person } from '@api/people/person';

import { JoiningQuestionsComponent } from '../joining-questions/joining-questions.component';
import { MoreDetailsComponent } from '../more-details/more-details.component';

@Component({
  selector: 'app-details',
  imports: [NgbCollapseModule, MoreDetailsComponent, JoiningQuestionsComponent],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css',
})
export class DetailsComponent {
  public readonly person = input<Person>();

  public readonly hideDetails = signal(true);

  public readonly hideJoining = signal(true);
}
