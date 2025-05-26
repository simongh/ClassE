using AutoMapper;

namespace ClassE.Types
{
    public interface IMapFrom<TSource>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TSource), GetType());
    }
}