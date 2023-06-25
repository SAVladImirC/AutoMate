using Data.Enumerations.RelatedData.PerformedService;
using Data.Models;
using Data.Responses;
using Repositories;

namespace Services
{
    public class PerformedServiceService
    {
        private readonly PerformedServiceRepository _performedServiceRepository;
        private readonly ReplacementRepository _replacementRepository;
    
        public PerformedServiceService(PerformedServiceRepository performedServiceRepository, ReplacementRepository replacementRepository)
        {
            _performedServiceRepository = performedServiceRepository;
            _replacementRepository = replacementRepository;
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                PerformedService? performedService = await _performedServiceRepository.FindSingle(v => v.Id == id);
                if (performedService != null)
                {
                    await _performedServiceRepository.LoadRelatedCollection(performedService, PerformedServiceRelatedDataCollections.REPLACEMENTS);
                    await _performedServiceRepository.LoadRelatedReference<Invoice>(performedService, PerformedServiceRelatedDataReferences.INVOICE);
                    await _performedServiceRepository.LoadRelatedReference<ServiceStation>(performedService, PerformedServiceRelatedDataReferences.SERVICE_STATION);
                    await _performedServiceRepository.LoadRelatedReference<Service>(performedService, PerformedServiceRelatedDataReferences.SERVICE);
                    foreach (Replacement r in performedService.Replacements)
                    {
                        await _replacementRepository.LoadRelatedReference(r);
                    }
                    return new SuccessResponse<PerformedService?>() { Data = performedService };
                }
                return new ErrorResponse() { Message = "Не постои возило со зададеното ID" };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }
    }
}
