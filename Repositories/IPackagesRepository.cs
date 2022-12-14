using ConsumptionAPI.Models.Domain;
using ConsumptionAPI.Models.DTO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConsumptionAPI.Repositories
{
    public interface IPackagesRepository
    {
        Task<ConsumptionAPI.Models.Domain.TPackage> GetAsync(int IdVehicule);
    }
}
