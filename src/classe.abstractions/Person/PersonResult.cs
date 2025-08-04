using AutoMapper;
using System.Text.Json;

namespace ClassE.Person
{
    public record PersonResult
    {
        private string? _joiningQuestions;

        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public float Balance { get; init; }

        public string? Address { get; init; }

        public DateTime DateOfBirth { get; init; }

        public Entities.Gender Gender { get; init; }

        public string? Occupation { get; set; }

        public string? EmergencyContact { get; set; }

        public string? EmergencyContactNumber { get; set; }

        public string? Notes { get; set; }

        public DateTime? ConsentDate { get; set; }

        public JoiningQuestionsModel? JoiningQuestions => JsonSerializer.Deserialize<JoiningQuestionsModel>(_joiningQuestions ?? "{}");

        public IEnumerable<BookingResult> Bookings { get; set; } = null!;
        public IEnumerable<BookingResult> WaitingList { get; set; } = null!;

        public IEnumerable<Models.PaymentModel> Payments { get; set; } = null!;

        public IEnumerable<SessionResult> Sessions { get; set; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Person, PersonResult>()
                    .ForMember(p => p._joiningQuestions, config => config.MapFrom(p => p.JoiningNotes))
                    .ForMember(p => p.Bookings, config => config.MapFrom(p => p.Bookings
                        .Where(b => !b.WaitingList)
                        .OrderBy(b => b.Class.DayOfWeek).ThenBy(b => b.Class.StartTime)))
                    .ForMember(p => p.WaitingList, config => config.MapFrom(p => p.Bookings
                        .Where(b => b.WaitingList)
                        .OrderBy(b => b.Class.DayOfWeek).ThenBy(b => b.Class.StartTime)))
                    .ForMember(p => p.Payments, config => config.MapFrom(p => p.Payments
                        .OrderByDescending(p => p.Created)
                        .Take(5)))
                    .ForMember(p => p.Sessions, config => config.MapFrom(p => p.Sessions
                        .OrderByDescending(s => s.Date)
                        .Take(5)));
            }
        }
    }
}