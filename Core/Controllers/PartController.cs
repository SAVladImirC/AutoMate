using Microsoft.AspNetCore.Http;
using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly PartService _partService;

        public PartController(PartService partService)
        {
            _partService = partService;
        }

        [HttpPost]
        public async Task<Response> GetByIds(List<int> ids)
        {
            return await _partService.GetByIds(ids);
        }
    }
}
