using Data;
using Data.Enumerations.RelatedData.Service;
using Data.Models;

namespace Repositories
{
    public class ReplacementRepository : GeneralRepository<Replacement>
    {
        public ReplacementRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Replacement replacement)
        {
            await _context.Entry(replacement).Reference(u => u.Part).LoadAsync();
        }
    }
}
