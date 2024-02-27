using BTAPI.Core.Interfaces;
using BTAPI.Core.Models;
using BTAPI.Services;
using BTAPI.Services.Interfaces;
using NSubstitute;

namespace BTAPI.Test
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IVehicleRepository _vehicleRepository;
        private IVehicleService _vehicleService;

        [SetUp]
        public void Setup()
        {
            _vehicleRepository = Substitute.For<IVehicleRepository>();
            _vehicleService = Substitute.For<IVehicleService>();
        }

        [Test]
        public void GetAllVehiclesByRestrictions_WithRestrictions_ReturnsFilteredVehicles()
        {
            // Arrange
            int pickupLocation = 1;
            int userLocation = 2;
            int returnLocation = 3;

            var vehicleList = new List<VehicleDetails>
            {
                new VehicleDetails { Id = 1, PickupId = 1, ReturnId = 1, LocationId = 2 },
                new VehicleDetails { Id = 2, PickupId = 1, ReturnId = 2, LocationId = 3 },
                new VehicleDetails { Id = 3, PickupId = 2, ReturnId = 3, LocationId = 1 }
            };

            _vehicleRepository.GetAvailableVehicles().Returns(vehicleList);

            // Act
            var result = _vehicleService.GetAllVehiclesByRestrictions(pickupLocation, userLocation, returnLocation);

            // Assert
            Assert.IsNotNull(result);
        }

    }
}