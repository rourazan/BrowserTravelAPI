using BTAPI.Core.Interfaces;
using BTAPI.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAPI.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext;

        protected GenericRepository(DbContextClass context)
        {
            _dbContext = context;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            // Si hay que discriminar diferentes formas de obtener dependiendo del tipo T
            if (typeof(T) != typeof(VehicleDetails))
            {
                return await GetVehicleDetails();
            }
            else
            {
                return await GetVehicleDetails();
            }
        }

        private async Task<IEnumerable<T>> GetVehicleDetails()
        {
            // Supongamos que aquí realizas alguna operación asincrónica para obtener los detalles de los vehículos
            var vehicleDetailsList = await ObtenerDetallesVehiculosAsincronicamente();

            // Aquí conviertes la lista de detalles de vehículos a una lista de tipo T (en este caso, VehicleDetails)
            var convertedList = vehicleDetailsList.ConvertAll(x => (T)(object)x);

            return convertedList;
        }

        private Task<List<VehicleDetails>> ObtenerDetallesVehiculosAsincronicamente()
        {
            // Supongamos que aquí realizas alguna operación asincrónica para obtener los detalles de los vehículos
            return Task.FromResult(new List<VehicleDetails>
            {
                new VehicleDetails { Id = 1, Model = 2015, Brand = "Marca 1" },
                new VehicleDetails { Id = 2, Model = 2018, Brand = "Marca 2" }
            });
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
