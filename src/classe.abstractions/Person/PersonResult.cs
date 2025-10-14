using AutoMapper;
using System.Text.Json;

namespace ClassE.Person
{
    public record PersonResult : PersonModel
    {
        private readonly string? _joiningQuestions;

        public float Balance { get; init; }

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
                    .ForMember(p => p.Bookings, config => config.Ignore())
                    .ForMember(p => p.WaitingList, config => config.Ignore())
                    .ForMember(p => p.Payments, config => config.Ignore())
                    .ForMember(p => p.Sessions, config => config.Ignore());
            }
        }
    }
}