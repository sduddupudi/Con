using ConsumptionAPI.Data;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConsumptionAPI.Repositories
{
    public class TraceRepository : ITraceRepository
    {
        private readonly MauffreyDBContext mauffreyDBContext;

        public TraceRepository(MauffreyDBContext nmauffreyDBContext)
        {
           mauffreyDBContext= nmauffreyDBContext;
        }

        public async Task<int> GetTotalKMAsync(string SerialBoitier, DateTime startDate, DateTime ednDate)
        {
            int TotalKMTravelled = 0;
            var vTraceResult = await mauffreyDBContext.VTraces.Where(r => r.SerialBoitier == SerialBoitier && r.IndexKm != 0 && r.DateTraces >= startDate && r.DateTraces <= ednDate).ToListAsync();

            var MinKmTravelled = vTraceResult.OrderBy(x => x.DateTraces)?.First();
            var MaxKmTravelled = vTraceResult.OrderBy(x => x.DateTraces)?.Last();

            TotalKMTravelled = (Convert.ToInt32(MaxKmTravelled?.IndexKm) - Convert.ToInt32(MinKmTravelled?.IndexKm));
            return  TotalKMTravelled;
        }

        public async Task<IEnumerable<VTrace>> GetTraceonDateAsync(string SerialBoitier, DateTime startDate, DateTime ednDate)
        {
            return await mauffreyDBContext.VTraces.Where(r => r.SerialBoitier == SerialBoitier && r.IndexKm != 0 && r.DateTraces >= startDate && r.DateTraces <= ednDate).ToListAsync() ;
        }
    }
}
