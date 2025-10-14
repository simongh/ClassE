using AutoMapper;

namespace ClassE.Person
{
    public record SummaryResult : PersonBaseModel
    {
        public int Id { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Person, SummaryResult>();
            }
        }
    }
}