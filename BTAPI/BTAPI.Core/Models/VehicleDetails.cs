using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Core.Models
{
    public class VehicleDetails
    {
        public int Id { get; set; }
        public int Model { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public int Year { get; set; }
        public int LocationId { get; set; }
        public int PickupId { get; set; }
        public int ReturnId { get; set; }
    }
}
