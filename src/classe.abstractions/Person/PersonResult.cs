using AutoMapper;
using ClassE.Types;

namespace ClassE.Person
{
    public record PersonResult : IMapFrom<Entities.Person>
    {
        public string FirstName { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string? Email { get; init; }

        public string? Phone { get; init; }

        public int Credits { get; init; }

        public IEnumerable<BookingResult> Bookings { get; set; } = null!;
        public IEnumerable<BookingResult> WaitingList { get; set; } = null!;

        public IEnumerable<Models.PaymentModel> Payments { get; set; } = null!;

        public IEnumerable<SessionResult> Sessions { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Person, PersonResult>()
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