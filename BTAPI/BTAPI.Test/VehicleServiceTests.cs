using BTAPI.Core.Interfaces;
using BTAPI.Core.Models;
using BTAPI.Services;
using BTAPI.Services.Interfaces;
using BTAPI.Test.Models;
using NSubstitute;

namespace BTAPI.Test
{
    [TestFixture]
    public class VehicleServiceTests
    {
        private IUnitOfWork _unitOfWork;
        private VehicleService _vehicleService;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _vehicleService = new VehicleService(_unitOfWork);
        }

        [Test]
        public void GetAllVehiclesByRestrictions_Done()
        {
            int pickupLocation = 1;
            int userLocation = 2;
            int returnLocation = 3;

            VehicleModelTest vehicleModelTest = new VehicleModelTest();

            var vehicleList = vehicleModelTest.VehicleList;

            _unitOfWork.Vehicles.GetAvailableVehicles().Returns(vehicleList);

            var result = _vehicleService.GetAllVehiclesByRestrictions(pickupLocation, userLocation, returnLocation);

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetAllVehiclesByPickupLocation_Done()
        {
            int pickupLocation = 1;

            VehicleModelTest vehicleModelTest = new VehicleModelTest();

            var vehicleList = vehicleModelTest.VehicleList;

            _unitOfWork.Vehicles.GetAvailableVehicles().Returns(vehicleList);

            var result = _vehicleService.GetAllVehiclesByPickupLocation(vehicleList, pickupLocation);

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetAllVehiclesByReturnLocation_Done()
        {
            int returnLocation = 3;

            VehicleModelTest vehicleModelTest = new VehicleModelTest();

            var vehicleList = vehicleModelTest.VehicleList;

            _unitOfWork.Vehicles.GetAvailableVehicles().Returns(vehicleList);

            var result = _vehicleService.GetAllVehiclesByReturnLocation(vehicleList, returnLocation);

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetAllVehiclesByUserLocation_Done()
        {
            int userLocation = 2;

            VehicleModelTest vehicleModelTest = new VehicleModelTest();

            var vehicleList = vehicleModelTest.VehicleList;

            _unitOfWork.Vehicles.GetAvailableVehicles().Returns(vehicleList);

            var result = _vehicleService.GetAllVehiclesByUserLocation(vehicleList, userLocation);

            Assert.That(result.Count, Is.GreaterThan(0));
        }

    }
}