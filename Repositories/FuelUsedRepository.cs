using ConsumptionAPI.Data;
using ConsumptionAPI.Models.Domain;
using ConsumptionAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Repositories
{
    public class FuelUsedRepository : IFuelUsedRepository
    {
        private readonly AGV4MainContext aGV4MainContext;

        public FuelUsedRepository(AGV4MainContext naGV4MainContext)
        {
            aGV4MainContext= naGV4MainContext;
        }
        
        public async Task<IEnumerable<Models.Domain.TotalFuelUsed>> GetAsync(long imei, DateTime fromDate, DateTime endDate)
        {
            return await aGV4MainContext.TotalFuelUseds.Where(x => (x.Imei.ToString() == imei.ToString()) && x.TimestampUtc > Convert.ToDateTime(fromDate) && x.TimestampUtc < Convert.ToDateTime(endDate)).ToListAsync();
        }

        public async Task<int> GetTotalFuelUsedAsync(long imei, DateTime fromDate, DateTime endDate)
        {

            int TotalFuelConsumed = 0;
            var TotalFuelUsed = await aGV4MainContext.TotalFuelUseds.Where(x => (x.Imei.ToString() == imei.ToString()) && x.TimestampUtc > Convert.ToDateTime(fromDate) && x.TimestampUtc < Convert.ToDateTime(endDate)).ToListAsync();

            var MinFuelUsed = TotalFuelUsed.OrderBy(x => x.TimestampUtc).First();
            var MaxFuelUsed = TotalFuelUsed.OrderBy(x => x.TimestampUtc).Last();

            TotalFuelConsumed = (Convert.ToInt32(MaxFuelUsed.LowRes) - Convert.ToInt32(MinFuelUsed.LowRes)) / 100;

            return  TotalFuelConsumed;
        }


        public async Task <double> GetTotalFuelExtendedUsedAsync(int VehicleId, DateTime fromDate, DateTime endDate)
        {
            double TotalFuelConsumed = 0;
            var TotalFuelUsed = await aGV4MainContext.VehicleStats.Where(x => (x.VehicleId.ToString() == VehicleId.ToString()) && x.PeriodMin >= Convert.ToDateTime(fromDate) && x.PeriodMax < Convert.ToDateTime(endDate)).ToListAsync();
            TotalFuelConsumed=TotalFuelUsed.Sum(x => (x.VolumeStart - x.VolumeEnd + x.Refueling)); 
            return TotalFuelConsumed;
        }

        public async Task<long> GetTotalDistanceExtendedUsedAsync(int VehicleId, DateTime fromDate, DateTime endDate)
        {
            long TotalDistanceConsumed = 0;
            var TotalFuelUsed = await aGV4MainContext.VehicleStats.Where(x => (x.VehicleId.ToString() == VehicleId.ToString()) && x.PeriodMin >= Convert.ToDateTime(fromDate) && x.PeriodMax < Convert.ToDateTime(endDate)).ToListAsync();
            TotalDistanceConsumed = (int)TotalFuelUsed.Sum(item => item.GpsDistanceFirst + (item.LastIndex.Value - item.FirstIndex.Value)+item.GpsindexEnd);

           // TotalDistanceConsumed = (long)TotalFuelUsed.Sum(x => x.GpsDistanceFirst + Convert.ToInt16(x.LastIndex.HasValue ? x.LastIndex : 0) - Convert.ToInt16(x.FirstIndex.HasValue ? x.FirstIndex : 0) + x.GpsindexEnd);
            return TotalDistanceConsumed;
        }



    }
}
