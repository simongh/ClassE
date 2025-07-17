namespace ClassE.Person
{
    public class JoiningQuestionsModel
    {
        public bool RegularExercise { get; init; }
        public string? OtherExercise { get; init; }
        public string? Goals { get; init; }
        public string? ExistingMedicalConditions { get; init; }
        public bool JointInjuries { get; init; }
        public string? AdditionalNeeds { get; init; }

        public string? DoctorRecommendations { get; init; }

        public bool PainOnPhysicalActivity { get; init; }

        public bool ChestPain { get; init; }
        public bool Dizziness { get; init; }
        public bool DoctorPrescribedDrugs { get; init; }
        public bool BoneOrJointProblems { get; init; }
        public bool Epilepsy { get; init; }
        public bool Diabetes { get; init; }
        public bool Asthma { get; init; }
        public bool AnyReasonNotToDoPhysicalActivity { get; init; }
        public bool DiscussedAboveWithDoctor { get; init; }
        public string? AdditionalInfo { get; init; }
    }
}