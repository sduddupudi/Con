using ConsumptionAPI.Data;
using ConsumptionAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsumptionAPI.Repositories;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;
using System;

namespace ConsumptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : Controller
    {
       
        private readonly IVehiculeRepository vehicleRepository;
        private readonly IFuelUsedRepository fuelUsedRepository;
        private readonly IPackagesRepository packagesRepository;
        private readonly ITraceRepository traceRepository;
        private readonly IMapper mapper;
        public ConsumptionController(IVehiculeRepository vehiculeRepository,IFuelUsedRepository fuelUsedRepository,IPackagesRepository packagesRepository,ITraceRepository traceRepository,IMapper mapper)
        {
          this.vehicleRepository= vehiculeRepository;
            this.fuelUsedRepository= fuelUsedRepository;
            this.packagesRepository= packagesRepository;    
            this.traceRepository= traceRepository;
            this.mapper= mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<Consumption>> GetVehicles(int VehicleID, string RegistrationNumber, DateTime StartDate, DateTime EndDate)
        {
            Consumption consumption=new Consumption();
            DateTime startdateTime= Convert.ToDateTime(StartDate);
            DateTime enddateTime = Convert.ToDateTime(EndDate);
            consumption.StartDate = StartDate;
            consumption.EndDate=EndDate;
            TVehicule tvehicle;
            if (VehicleID!=0)
            {
                 tvehicle = await vehicleRepository.GetVehicleIdAsync(VehicleID);
                 RegistrationNumber = tvehicle.Immatriculation;
            }
            else
            {
                 tvehicle = await vehicleRepository.GetImmatriculationAsync(RegistrationNumber);
            }                         
            if (tvehicle != null)
            {
                consumption.EnergyType= await vehicleRepository.GetVehicleEnergyTypeAsync(tvehicle.IdVehicule);
                if (enddateTime.Subtract(startdateTime).Days > 2)
                {
                    consumption.TotalVolume =(int)await fuelUsedRepository.GetTotalFuelExtendedUsedAsync(tvehicle.IdVehicule, startdateTime, enddateTime);
                    consumption.TotalDistance = (int)await fuelUsedRepository.GetTotalDistanceExtendedUsedAsync(tvehicle.IdVehicule, startdateTime, enddateTime);
                    return Ok(consumption);
                }
                else
                {
                    var tpackage = await packagesRepository.GetAsync(tvehicle.IdVehicule);
                    if (tpackage != null)
                    {
                        try
                        {
                            if (tpackage.SerialBoitier != null)
                                consumption.TotalDistance = await traceRepository.GetTotalKMAsync(tpackage.SerialBoitier, startdateTime, enddateTime);
                            if (tpackage.Imei != null)
                                consumption.TotalVolume = await fuelUsedRepository.GetTotalFuelUsedAsync(long.Parse(tpackage.Imei), startdateTime, enddateTime);

                        }
                        catch (Exception Ex)
                        {
                            return NotFound("No Data Found");
                        }
                    }
                    return Ok(consumption);
                }
            }
            else
            {
                return NotFound("No Data Found");
            }

        }
    }    
}
