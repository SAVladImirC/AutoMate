using Data;
using Data.Enumerations.RelatedData.ServiceStation;
using Data.Models;

namespace Repositories
{
    public class ServiceStationRepository : GeneralRepository<ServiceStation>
    {
        public ServiceStationRepository(AutoMateDbContext context) : base(context)
        {
        }

        public void LoadRelatedCollection<T>(ServiceStation serviceStation, ServiceStationRelatedDataCollections collection, Func<T, bool> expression) where T : class
        {
            switch (collection)
            {
                case ServiceStationRelatedDataCollections.OFFERS:
                    {
                        _ = _context.Entry(serviceStation)
                                .Collection(ss => ss.Offers)
                                .Query()
                                .Where((Func<Offer, bool>)expression).ToList();
                    }
                    break;
                case ServiceStationRelatedDataCollections.SELLS:
                    {
                        _ = _context.Entry(serviceStation)
                                .Collection(ss => ss.Sale)
                                .Query()
                                .Where((Func<Sell, bool>)expression).ToList();
                    }
                    break;
            }
        }

        public async Task LoadRelatedCollection(ServiceStation serviceStation, ServiceStationRelatedDataCollections collection)
        {
            switch (collection)
            {
                case ServiceStationRelatedDataCollections.OFFERS:
                    {
                        await _context.Entry(serviceStation)
                                .Collection(ss => ss.Offers).LoadAsync();
                    }
                    break;
                case ServiceStationRelatedDataCollections.SELLS:
                    {
                        await _context.Entry(serviceStation)
                                .Collection(ss => ss.Sale).LoadAsync();
                    }
                    break;
            }
        }
    }
}
