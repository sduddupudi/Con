using AutoMapper;

namespace ConsumptionAPI.Profiles
{
    public class TPackagesProfile:Profile
    {
        public TPackagesProfile()
        {
            CreateMap<Models.Domain.TPackage,Models.DTO.TPackage>();
        }
    }
}
