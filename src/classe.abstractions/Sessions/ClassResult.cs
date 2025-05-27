using AutoMapper;

namespace ClassE.Sessions
{
    public record ClassResult : Types.IMapFrom<Entities.Class>
    {
        public int Id { get; init; }

        public int StartTime { get; init; }

        public int Duration { get; init; }

        public IEnumerable<Models.BookingResult> Bookings { get; init; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Entities.Class, ClassResult>()
                .ForMember(m => m.Bookings, config => config.MapFrom(m => m.Bookings
                    .Where(b => !b.WaitingList)
                    .OrderBy(b => b.Person.FirstName)
                    .ThenBy(b => b.Person.LastName)));
        }
    }
}