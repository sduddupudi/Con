
using AutoMapper;

namespace ConsumptionAPI.Profiles
{
    public class TVehiculesProfile:Profile
    {
        public TVehiculesProfile()
        {
                CreateMap<Models.Domain.TVehicule,Models.DTO.TVehicule>();
        }
    }
}
