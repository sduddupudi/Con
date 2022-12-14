using ConsumptionAPI.Models.Domain;
using ConsumptionAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumptionAPI.Repositories
{
    public interface IFuelUsedRepository
    {
        Task<IEnumerable<ConsumptionAPI.Models.Domain.TotalFuelUsed>> GetAsync(long imei,DateTime fromDate,DateTime endDate);
        Task<int> GetTotalFuelUsedAsync(long imei, DateTime fromDate, DateTime endDate);
        Task<long> GetTotalDistanceExtendedUsedAsync(int VehicleId, DateTime fromDate, DateTime endDate);
        Task<double> GetTotalFuelExtendedUsedAsync(int VehicleId, DateTime fromDate, DateTime endDate);
    }
}
