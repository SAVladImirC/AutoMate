using Data;
using Data.Models;

namespace Repositories
{
    public class ModelRepository : GeneralRepository<Model>
    {
        public ModelRepository(AutoMateDbContext context) : base(context)
        {
        }

        public async Task LoadRelatedReference(Model model)
        {
            await _context.Entry(model).Reference(u => u.Brand).LoadAsync();
        }
    }
}
