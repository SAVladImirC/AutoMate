using Data;
using Data.Models;

namespace Repositories
{
    public class SaleRepository : GeneralRepository<Sell>
    {
        public SaleRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Sell sell)
        {
            await _context.Entry(sell).Reference(u => u.Part).LoadAsync();
        }
    }
}
