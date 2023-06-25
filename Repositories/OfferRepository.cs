using Data;
using Data.Models;

namespace Repositories
{
    public class OfferRepository : GeneralRepository<Offer>
    {
        public OfferRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Offer offer)
        {
            await _context.Entry(offer).Reference(u => u.Service).LoadAsync();
        }
    }
}
