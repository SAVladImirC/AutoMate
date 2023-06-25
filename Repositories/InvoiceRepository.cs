using Data;
using Data.Enumerations.RelatedData.PerformedService;
using Data.Models;

namespace Repositories
{
    public class InvoiceRepository : GeneralRepository<Invoice>
    {
        public InvoiceRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedCollection(Invoice invoice)
        {
            await _context.Entry(invoice)
                    .Collection(ps => ps.PerformedServices).LoadAsync();

            await _context.Entry(invoice)
                    .Reference(ps => ps.Client).LoadAsync();

            await _context.Entry(invoice)
                    .Reference(ps => ps.Provider).LoadAsync();

        }
    }
}
