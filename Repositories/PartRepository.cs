using Data;
using Data.Models;

namespace Repositories
{
    public class PartRepository : GeneralRepository<Part>
    {
        public PartRepository(AutoMateDbContext context) : base(context)
        {
        }
    }
}
