using Data;
using Data.Enumerations.RelatedData.User;
using Data.Models;

namespace Repositories
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(AutoMateDbContext context) : base(context)
        {

        }

        public async Task LoadRelatedReference<T>(User user, UserRelatedDataReferences reference) where T : Address
        {

            switch (reference)
            {
                case UserRelatedDataReferences.ADDRESS:
                    {
                        await _context.Entry(user).Reference(u => u.Address).LoadAsync();
                    }
                    break;

            }
        }

        public void LoadRelatedCollection<T>(User user, UserRelatedDataCollections collection, Func<T, bool> expression) where T : class
        {
            switch (collection)
            {
                case UserRelatedDataCollections.SERVICE_STATIONS:
                    {
                        _ = _context.Entry(user)
                                .Collection(u => u.ServiceStations)
                                .Query()
                                .Where((Func<ServiceStation, bool>)expression).ToList();
                    }
                    break;
                case UserRelatedDataCollections.VEHICLES:
                    {
                        _ = _context.Entry(user)
                                .Collection(u => u.Vehicles)
                                .Query()
                                .Where((Func<Vehicle, bool>)expression).ToList();
                    }
                    break;
                case UserRelatedDataCollections.INVOICES:
                    {
                        _ = _context.Entry(user)
                                .Collection(u => u.Vehicles)
                                .Query()
                                .Where((Func<Vehicle, bool>)expression).ToList();
                    }
                    break;
            }
        }

        public async Task LoadRelatedCollection(User user, UserRelatedDataCollections collection)
        {
            switch (collection)
            {
                case UserRelatedDataCollections.SERVICE_STATIONS:
                    {
                        await _context.Entry(user)
                                .Collection(u => u.ServiceStations).LoadAsync();
                    }
                    break;
                case UserRelatedDataCollections.VEHICLES:
                    {
                        await _context.Entry(user)
                                .Collection(u => u.Vehicles).LoadAsync();
                    }
                    break;
                case UserRelatedDataCollections.INVOICES:
                    {
                        await _context.Entry(user)
                                .Collection(u => u.Vehicles).LoadAsync();
                    }
                    break;
            }
        }

    }
}
