import { Component, input } from '@angular/core';

import { Person } from '@api/people/person';

@Component({
  selector: 'app-joining-questions',
  imports: [],
  templateUrl: './joining-questions.component.html',
  styleUrl: './joining-questions.component.css'
})
export class JoiningQuestionsComponent {
  public readonly person = input<Person>();
}
