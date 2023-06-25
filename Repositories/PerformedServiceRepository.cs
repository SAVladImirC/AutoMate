using Data;
using Data.Enumerations.RelatedData.PerformedService;
using Data.Models;

namespace Repositories
{
    public class PerformedServiceRepository : GeneralRepository<PerformedService>
    {
        public PerformedServiceRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference<T>(PerformedService performedService, PerformedServiceRelatedDataReferences reference)
        {

            switch (reference)
            {
                case PerformedServiceRelatedDataReferences.INVOICE:
                    {
                        await _context.Entry(performedService).Reference(ps => ps.Invoice).LoadAsync();
                    }
                    break;
                case PerformedServiceRelatedDataReferences.SERVICE_STATION:
                    {
                        await _context.Entry(performedService).Reference(ps => ps.ServiceStation).LoadAsync();
                    }
                    break;
                case PerformedServiceRelatedDataReferences.SERVICE:
                    {
                        await _context.Entry(performedService).Reference(ps => ps.Service).LoadAsync();
                    }
                    break;

            }
        }

        public void LoadRelatedCollection<T>(PerformedService performedService, PerformedServiceRelatedDataCollections collection, Func<T, bool> expression) where T : class
        {
            switch (collection)
            {
                case PerformedServiceRelatedDataCollections.REPLACEMENTS:
                    {
                        _ = _context.Entry(performedService)
                                .Collection(ps => ps.Replacements)
                                .Query()
                                .Where((Func<Replacement, bool>)expression).ToList();
                    }
                    break;
            }
        }

        public async Task LoadRelatedCollection(PerformedService performedService, PerformedServiceRelatedDataCollections collection)
        {
            switch (collection)
            {
                case PerformedServiceRelatedDataCollections.REPLACEMENTS:
                    {
                        await _context.Entry(performedService)
                                .Collection(ps => ps.Replacements).LoadAsync();
                    }
                    break;
            }
        }
    }
}
