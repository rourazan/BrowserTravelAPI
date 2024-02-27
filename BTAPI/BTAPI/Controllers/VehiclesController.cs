using BTAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        public readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetVehicles")]
        public IActionResult GetAllVehiclesByRestrictions(int pickupLocation, int userLocation, int returnLocation)
        {
            var productDetailsList = _vehicleService.GetAllVehiclesByRestrictions(pickupLocation, userLocation, returnLocation);
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }
    }
}
