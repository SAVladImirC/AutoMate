using Data.Enumerations.RelatedData.Vehicle;
using Data.Models;
using Data.Responses;
using Repositories;

namespace Services
{
    public class PartService
    {
        private readonly PartRepository _partRepository;

        public PartService(PartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public async Task<Response> GetByIds(List<int> ids)
        {
            try
            {
                List<Part> parts = await _partRepository.FindAll(p => ids.Contains(p.Id));
                return new SuccessResponse<List<Part>>() { Data = parts };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }
    }
}
