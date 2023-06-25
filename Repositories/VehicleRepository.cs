using Data;
using Data.Enumerations.RelatedData.Vehicle;
using Data.Models;

namespace Repositories
{
    public class VehicleRepository : GeneralRepository<Vehicle>
    {
        public VehicleRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Vehicle vehicle, VehicleRelatedDataReferences reference)
        {

            switch (reference)
            {
                case VehicleRelatedDataReferences.OWNER:
                    {
                        await _context.Entry(vehicle).Reference(u => u.Owner).LoadAsync();
                    }
                    break;
                case VehicleRelatedDataReferences.MODEL:
                    {
                        await _context.Entry(vehicle).Reference(u => u.Model).LoadAsync();
                    }
                    break;

            }
        }

        public void LoadRelatedCollection<T>(Vehicle vehicle, VehicleRelatedDataCollections collection, Func<T, bool> expression) where T : class
        {
            switch (collection)
            {
                case VehicleRelatedDataCollections.PERFORMED_SERVICES:
                    {
                        _ = _context.Entry(vehicle)
                                .Collection(u => u.PerformedServices)
                                .Query()
                                .Where((Func<PerformedService, bool>)expression).ToList();
                    }
                    break;
            }
        }

        public async Task LoadRelatedCollection(Vehicle vehicle, VehicleRelatedDataCollections collection)
        {
            switch (collection)
            {
                case VehicleRelatedDataCollections.PERFORMED_SERVICES:
                    {
                        await _context.Entry(vehicle)
                                .Collection(v => v.PerformedServices).LoadAsync();
                    }
                    break;
            }
        }
    }
}
