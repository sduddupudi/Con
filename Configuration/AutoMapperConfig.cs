using System;
using System.Reflection;


namespace ConsumptionAPI
{
    internal partial class AutoMapperConfig : AutoMapper.Profile
    {
        private static readonly string CurrentTypeFullName
            = MethodBase.GetCurrentMethod().GetType().FullName;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
        public AutoMapperConfig()
        {
            //CreateMap<DbTour, TripOutDto>().ReverseMap();
           // CreateMap<DbPallet, PalletOutDto>().ReverseMap();
           // CreateMap<DbTour, TripInDto>().ReverseMap();
           // CreateMap<DbPallet, PalletInDto>().ReverseMap();
        }

        public override string ProfileName
        {
            get { return CurrentTypeFullName; }
        }
    }
}
