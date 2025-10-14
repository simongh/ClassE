using AutoMapper;

namespace ClassE.Payments
{
    public record PaymentResult : Models.PaymentModel
    {
        public Models.LookUpResult Person { get; init; } = null!;

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Entities.Payment, PaymentResult>()
                    .IncludeBase<Entities.Payment, Models.PaymentModel>();
            }
        }
    }
}