using AutoMapper;

namespace ConsumptionAPI.Profiles
{
    public class TotalFuelUsedProfile:Profile
    {
        public TotalFuelUsedProfile()
        {
            CreateMap<Models.Domain.TotalFuelUsed,Models.Domain.TotalFuelUsed>();
        }
    }
}
