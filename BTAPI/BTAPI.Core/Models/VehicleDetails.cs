using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Core.Models
{
    /// <summary>
    /// Representa los detalles de un vehículo.
    /// </summary>
    public class VehicleDetails
    {
        /// <summary>
        /// Obtiene o establece el identificador único del vehículo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el modelo del vehículo.
        /// </summary>
        public int Model { get; set; }

        /// <summary>
        /// Obtiene o establece la marca del vehículo.
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Obtiene o establece el tipo de vehículo.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Obtiene o establece el año de fabricación del vehículo.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la ubicación actual del vehículo.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la ubicación de recogida del vehículo.
        /// </summary>
        public int PickupId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la ubicación de devolución del vehículo.
        /// </summary>
        public int ReturnId { get; set; }
    }

}
