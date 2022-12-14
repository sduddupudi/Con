using ConsumptionAPI.Data;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConsumptionAPI.Repositories
{
    public class PackagesRepository : IPackagesRepository
    {
        private readonly BaseCentralContext baseCentralContext;

        public PackagesRepository(BaseCentralContext nbaseCentralContext)
        {
            baseCentralContext= nbaseCentralContext;
        }
        

        public async Task<TPackage> GetAsync(int IdVehicule)
        {

            return await baseCentralContext.TPackages.FirstOrDefaultAsync<TPackage>(x => x.IdVehicule == IdVehicule);

        }
               
    }
}
