import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JoiningQuestionsComponent } from './joining-questions.component';

describe('JoiningQuestionsComponent', () => {
  let component: JoiningQuestionsComponent;
  let fixture: ComponentFixture<JoiningQuestionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JoiningQuestionsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JoiningQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
