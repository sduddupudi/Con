using ConsumptionAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Repositories
{
    public interface IVehiculeRepository
    {
        Task<TVehicule> GetImmatriculationAsync(String Immatriculation);
        Task<TVehicule> GetVehicleIdAsync(int VehicleID);

        Task<String?> GetVehicleEnergyTypeAsync(int VehicleID);

    }
}
