import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { EMPTY, of } from 'rxjs';

import { IdName } from '@api/idname';
import { PaymentModel } from '@api/payments/payment.model';
import { SearchQuery, toParams } from '@app-types/search-query';
import { SearchResults } from '@app-types/search-results';

import { Person } from './person';
import { PersonModel } from './person.model';
import { Summary } from './summary';

export type PersonForm = ReturnType<PersonService['form']>['value'];

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  readonly #httpClient = inject(HttpClient);

  readonly #fb = inject(NonNullableFormBuilder);

  public search(query: SearchQuery) {
    const p = toParams(query);
    return this.#httpClient.get<SearchResults<Summary>>('/api/people', {
      params: p,
    });
  }

  public get(id: number) {
    if (id === 0) {
      return of<Person | null>(null);
    } else {
      return this.#httpClient.get<Person>(`/api/people/${id}`);
    }
  }

  public delete(id: number) {
    return this.#httpClient.delete(`/api/people/${id}`);
  }

  public update(id: number, person: PersonForm) {
    return this.#httpClient.put(`/api/people/${id}`, person);
  }

  public create(person: PersonForm) {
    return this.#httpClient.post<number>('/api/people', person);
  }

  public list() {
    return this.#httpClient.get<IdName[]>('/api/people/list');
  }

  public form(person?: PersonModel | null) {
    return this.#fb.group({
      firstName: [person?.firstName ?? null, Validators.required],
      lastName: [person?.lastName ?? null, Validators.required],
      email: [person?.email ?? null, [Validators.email]],
      phone: [person?.phone ?? null],
      address: [person?.address ?? null],
      gender: [person?.gender ?? null],
      dateOfBirth: [person?.dateOfBirth ?? null],
      occupation: [person?.occupation ?? null],
      emergencyContact: [person?.emergencyContact ?? null],
      emergencyContactNumber: [person?.emergencyContactNumber ?? null],
      notes: [person?.notes ?? null],
      consentDate: [person?.consentDate ?? null],
      joiningQuestions: this.#fb.group({
        regularExercise: [person?.joiningQuestions.regularExercise ?? false],
        otherExercise: [person?.joiningQuestions.otherExercise ?? null],
        goals: [person?.joiningQuestions.goals ?? null],
        existingMedicalConditions: [person?.joiningQuestions.existingMedicalConditions ?? null],
        jointInjuries: [person?.joiningQuestions.jointInjuries ?? false],
        additionalNeeds: [person?.joiningQuestions.additionalNeeds ?? null],
        doctorRecommendations: [person?.joiningQuestions.doctorRecommendations ?? null],
        painOnPhysicalActivity: [person?.joiningQuestions.painOnPhysicalActivity ?? false],
        chestPain: [person?.joiningQuestions.chestPain ?? false],
        dizziness: [person?.joiningQuestions.dizziness ?? false],
        doctorPrescribedDrugs: [person?.joiningQuestions.doctorPrescribedDrugs ?? false],
        boneOrJointProblems: [person?.joiningQuestions.boneOrJointProblems ?? false],
        epilepsy: [person?.joiningQuestions.epilepsy ?? false],
        diabetes: [person?.joiningQuestions.diabetes ?? false],
        asthma: [person?.joiningQuestions.asthma ?? false],
        anyReasonNotToDoPhysicalActivity: [person?.joiningQuestions.anyReasonNotToDoPhysicalActivity ?? false],
        discussedAboveWithDoctor: [person?.joiningQuestions.discussedAboveWithDoctor ?? false],
        additionalInfo: [person?.joiningQuestions.additionalInfo ?? null],
      }),
    });
  }

  public payments(person: number) {
    return this.#httpClient.get<SearchResults<PaymentModel>>(`/api/people/${person}/payments`, {
      params: new HttpParams().set('limit', 5),
    });
  }
}
