using Data.Models;
using Data.Responses;
using Data.Enumerations.RelatedData.Vehicle;
using Repositories;
using Data.Enumerations.RelatedData.PerformedService;

namespace Services
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly PerformedServiceRepository _performedServiceRepository;
        private readonly ModelRepository _modelRepository;
        public VehicleService(VehicleRepository vehicleRepository, PerformedServiceRepository performedServiceRepository, ModelRepository modelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _performedServiceRepository = performedServiceRepository;
            _modelRepository = modelRepository;
        }


        public async Task<Response> GetVehiclesForUser(int userId)
        {
            try
            {
                List<Vehicle> vehicles = await _vehicleRepository.FindAll(v => v.OwnerId== userId);
                foreach(Vehicle vehicle in vehicles)
                {
                    await _vehicleRepository.LoadRelatedReference(vehicle, VehicleRelatedDataReferences.MODEL);
                    await _modelRepository.LoadRelatedReference(vehicle.Model);
                }
                return new SuccessResponse<List<Vehicle>>() { Data = vehicles };
            }
            catch(Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                Vehicle? vehicle = await _vehicleRepository.FindSingle(v => v.Id == id);
                if (vehicle != null)
                {
                    await _vehicleRepository.LoadRelatedCollection(vehicle, VehicleRelatedDataCollections.PERFORMED_SERVICES);
                    await _vehicleRepository.LoadRelatedReference(vehicle, VehicleRelatedDataReferences.MODEL);
                    await _modelRepository.LoadRelatedReference(vehicle.Model);
                    foreach(PerformedService p in vehicle.PerformedServices)
                    {
                        await _performedServiceRepository.LoadRelatedReference<Service>(p, PerformedServiceRelatedDataReferences.SERVICE);
                    }
                    return new SuccessResponse<Vehicle?>() { Data = vehicle };
                }
                return new ErrorResponse() { Message = "Не постои возило со зададеното ID" };
            }
            catch(Exception e)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }
    }
}
