using AutoMapper;

namespace ClassE.Models
{
    public record PaymentModel
    {
        public int? Id { get; init; }

        public DateTime Created { get; init; }

        public float Amount { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Payment, PaymentModel>();
            }
        }
    }
}