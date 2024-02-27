using BTAPI.Core.Interfaces;
using BTAPI.Core.Models;
using BTAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Services
{
    public class VehicleService : IVehicleService
    {
        public IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<VehicleDetails> GetAllVehiclesByRestrictions(int pickupLocation, int userLocation, int returnLocation)
        {
            var vehicleDetailsAvailableList = _unitOfWork.Vehicles.GetAvailableVehicles();

            //Se determina darle prioridad a la localidad de recogida
            var vehiclePickup = (vehicleDetailsAvailableList.Count > 0 && pickupLocation > 0) ? GetAllVehiclesByPickupLocation(vehicleDetailsAvailableList, pickupLocation) : vehicleDetailsAvailableList;

            //Luego se filtra por la localidad del usuario
            var vehiclePickupUserLocation = (vehiclePickup.Count > 0 && userLocation > 0) ? GetAllVehiclesByUserLocation(vehiclePickup, userLocation) : vehiclePickup;

            //Y por ultimo se filtra por la localidad de devolucion se asume que constantemente LocationId del vehiculo se va actualizando cuando va a una nueva localidad
            var vehiclePickupUserLocationReturnLocation = (vehiclePickupUserLocation.Count > 0 && returnLocation > 0) ? GetAllVehiclesByReturnLocation(vehiclePickupUserLocation, returnLocation) : vehiclePickupUserLocation;

            //Cabe resaltar que los filtros segun la historia de usuario puede venir filtrado desde el front dejando solo la tarea de filtrado al back

            return vehiclePickupUserLocationReturnLocation;
        }

        public List<VehicleDetails> GetAllVehiclesByPickupLocation(List<VehicleDetails> vehicleList, int pickupLocation)
        {
            return vehicleList.Where(x => x.PickupId == pickupLocation).ToList();
        }

        public List<VehicleDetails> GetAllVehiclesByReturnLocation(List<VehicleDetails> vehicleList, int returnLocation)
        {
            return vehicleList.Where(x => x.ReturnId == returnLocation).ToList();
        }

        public List<VehicleDetails> GetAllVehiclesByUserLocation(List<VehicleDetails> vehicleList, int userLocation)
        {
            return vehicleList.Where(x => x.LocationId == userLocation).ToList();
        }
    }
}
