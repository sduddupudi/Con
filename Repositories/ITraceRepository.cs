using ConsumptionAPI.Models.Domain;
using ConsumptionAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Repositories
{
    public interface ITraceRepository
    {
        Task<IEnumerable<Models.Domain.VTrace>> GetTraceonDateAsync(string SerialBoitier,DateTime startDate,DateTime ednDate);

        Task<int> GetTotalKMAsync(string SerialBoitier, DateTime startDate, DateTime ednDate);

    }
}
