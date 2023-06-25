using Data;
using Data.Enumerations.RelatedData.Service;
using Data.Models;

namespace Repositories
{
    public class ServiceRepository : GeneralRepository<Service>
    {
        public ServiceRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Service service, ServiceRelatedDataReferences reference)
        {

            switch (reference)
            {
                case ServiceRelatedDataReferences.PERFORMED_SERVICE:
                    {
                        await _context.Entry(service).Reference(u => u.PerformedService).LoadAsync();
                    }
                    break;
            }
        }
    }
}
