using Data.Enumerations.RelatedData.Vehicle;
using Data.Models;
using Data.Responses;
using Repositories;

namespace Services
{
    public class ServiceService
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceService(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                Service? service = await _serviceRepository.FindSingle(s => s.Id == id);
                if (service != null)
                {
                    //await _vehicleRepository.LoadRelatedCollection(vehicle, VehicleRelatedDataCollections.PERFORMED_SERVICES);
                    //await _vehicleRepository.LoadRelatedReference(vehicle, VehicleRelatedDataReferences.MODEL);
                    //await _vehicleRepository.LoadRelatedReference(vehicle, VehicleRelatedDataReferences.OWNER);
                    return new SuccessResponse<Service?>() { Data = service };
                }
                return new ErrorResponse() { Message = "Не постои возило со зададеното ID" };
            }
            catch(Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }
    }
}
