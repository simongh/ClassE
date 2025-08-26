import { dateString } from '@app-types/dateString';
import { Gender } from '@app-types/gender';

export interface PersonModel {
  firstName: string;
  lastName: string;
  email: string | null;
  phone: string | null;
  address: string | null;
  dateOfBirth: dateString;
  gender: Gender;
  occupation: string | null;
  emergencyContact: string | null;
  emergencyContactNumber: string | null;
  notes: string | null;
  consentDate: dateString;
  joiningQuestions: {
    regularExercise: boolean;
    otherExercise: string | null;
    goals: string | null;
    existingMedicalConditions: string | null;
    jointInjuries: boolean;
    additionalNeeds: string | null;
    doctorRecommendations: string | null;
    painOnPhysicalActivity: boolean;
    chestPain: boolean;
    dizziness: boolean;
    doctorPrescribedDrugs: boolean;
    boneOrJointProblems: boolean;
    epilepsy: boolean;
    diabetes: boolean;
    asthma: boolean;
    anyReasonNotToDoPhysicalActivity: boolean;
    discussedAboveWithDoctor: boolean;
    additionalInfo: string | null;
  };
}
