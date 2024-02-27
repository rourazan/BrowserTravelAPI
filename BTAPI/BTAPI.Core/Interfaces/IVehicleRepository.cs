using BTAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Core.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<VehicleDetails>
    {
        List<VehicleDetails> GetAvailableVehicles();
    }
}
