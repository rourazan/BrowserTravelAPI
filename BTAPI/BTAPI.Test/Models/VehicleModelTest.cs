using BTAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Test.Models
{
    public class VehicleModelTest
    {
        public List<VehicleDetails> VehicleList { get; set; }

        public VehicleModelTest()
        {
            VehicleList = new List<VehicleDetails>
            {
                new VehicleDetails { Id = 1, PickupId = 1, ReturnId = 3, LocationId = 2 },
                new VehicleDetails { Id = 2, PickupId = 1, ReturnId = 2, LocationId = 3 },
                new VehicleDetails { Id = 3, PickupId = 2, ReturnId = 3, LocationId = 1 }
            };
        }
    }
}
