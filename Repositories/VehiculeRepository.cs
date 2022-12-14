using ConsumptionAPI.Data;
using ConsumptionAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumptionAPI.Repositories
{
    public class VehiculeRepository : IVehiculeRepository
    {
        private readonly BaseCentralContext baseCentralContext;

        public VehiculeRepository(BaseCentralContext nbaseCentralContext)
        {
            baseCentralContext= nbaseCentralContext;    
        }
               
        public async Task<TVehicule> GetImmatriculationAsync(string Immatriculation)
        {
            return await baseCentralContext.TVehicules.FirstOrDefaultAsync(x => x.Immatriculation == Immatriculation);
        }

        public async Task<TVehicule> GetVehicleIdAsync(int VehicleID)
        {
            return await baseCentralContext.TVehicules.FirstOrDefaultAsync(x => x.IdVehicule == VehicleID);
        }

        public async Task<string?> GetVehicleEnergyTypeAsync(int VehicleID)
        {
            Models.Domain.VehicleEnergyType _vehicleEnergyTypes;
            _vehicleEnergyTypes = await baseCentralContext.VehicleEnergyTypes.FirstOrDefaultAsync(x => x.VehicleId == VehicleID);
            FuelTypenum Fuelype = (FuelTypenum)_vehicleEnergyTypes.EnergyType;
            return Fuelype.ToString();
        }

          public void MyEnumMethod(Enum e)
    {
        var enumValues = Enum.GetValues(e.GetType());

        // you can iterate over enumValues with foreach
    }


    }
}
