using BTAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Services.Interfaces
{
    public interface IVehicleService
    {
        IEnumerable<VehicleDetails> GetAllVehiclesByRestrictions(int pickupLocation, int userLocation, int returnLocation);

        List<VehicleDetails> GetAllVehiclesByPickupLocation(List<VehicleDetails> vehicleList, int pickupLocation);

        List<VehicleDetails> GetAllVehiclesByUserLocation(List<VehicleDetails> vehicleList, int userLocation);

        List<VehicleDetails> GetAllVehiclesByReturnLocation(List<VehicleDetails> vehicleList, int returnLocation);
    }
}
