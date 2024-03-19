using System.Collections.Generic;
using vehicle_registration_app.Models;
using vehicle_registration_app.Repositories;
namespace vehicle_registration_app.Services

{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetById(id);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }

        public void DeleteVehicle(int id)
        {
            _vehicleRepository.Delete(id);
        }
    }
}
