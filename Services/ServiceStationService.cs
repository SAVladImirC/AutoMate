using Data.Enumerations.RelatedData.Vehicle;
using Data.Models;
using Data.Responses;
using Repositories;

namespace Services
{
    public class ServiceStationService
    {
        private readonly ServiceStationRepository _serviceStationRepository;
        private readonly OfferRepository _offerRepository;
        private readonly SaleRepository _saleRepository;

        public ServiceStationService(ServiceStationRepository serviceStationRepository, OfferRepository offerRepository, SaleRepository saleRepository)
        {
            _serviceStationRepository = serviceStationRepository;
            _offerRepository = offerRepository;
            _saleRepository = saleRepository;
        }

        public async Task<Response> GetAll()
        {
            try
            {
                List<ServiceStation> serviceStations = await _serviceStationRepository.FindAll(ss => true);
                return new SuccessResponse<List<ServiceStation>>() { Data = serviceStations };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                ServiceStation? serviceStation = await _serviceStationRepository.FindSingle(ss => ss.Id == id);
                if (serviceStation != null)
                {
                    await _serviceStationRepository.LoadRelatedCollection(serviceStation, Data.Enumerations.RelatedData.ServiceStation.ServiceStationRelatedDataCollections.OFFERS);
                    await _serviceStationRepository.LoadRelatedCollection(serviceStation, Data.Enumerations.RelatedData.ServiceStation.ServiceStationRelatedDataCollections.SELLS);
                    
                    foreach(Offer o in serviceStation.Offers)
                    {
                        await _offerRepository.LoadRelatedReference(o);
                    }

                    foreach (Sell s in serviceStation.Sale)
                    {
                        await _saleRepository.LoadRelatedReference(s);
                    }

                    return new SuccessResponse<ServiceStation?>() { Data = serviceStation };
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
