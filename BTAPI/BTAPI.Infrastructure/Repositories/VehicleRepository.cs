using BTAPI.Core.Interfaces;
using BTAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<VehicleDetails>, IVehicleRepository
    {
        public VehicleRepository(DbContextClass dbContext) : base(dbContext)
        {

        }

        public List<VehicleDetails> GetAvailableVehicles()
        {
            /*
             * Se deja el metodo que se cree aleatoriamente los vehiculos para simular cuando cambian de localidades
             * con ello cuando se solicitan puede que se muestren resultados o no segun sea la creacion
             */
            var vehicleDetailsList = new List<VehicleDetails>();

            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                int locationId = random.Next(1, 3);
                int pickupId = random.Next(1, 5); 
                int returnId = random.Next(1, 7); 

                VehicleDetails vehicleDetails = new VehicleDetails
                {
                    Id = i + 1,
                    Model = random.Next(2000, 2023), 
                    Brand = "Brand" + (i + 1),
                    Type = "Type" + (i + 1),
                    Year = random.Next(2000, 2023), 
                    LocationId = locationId,
                    PickupId = pickupId,
                    ReturnId = returnId
                };

                vehicleDetailsList.Add(vehicleDetails);
            }

            return vehicleDetailsList;
        }

    }
}
