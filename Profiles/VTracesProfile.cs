using AutoMapper;

namespace ConsumptionAPI.Profiles
{
    public class VTracesProfile:Profile
    {
        public VTracesProfile()
        {
            CreateMap<Models.Domain.VTrace, Models.DTO.VTrace>();
        }
    }
}
