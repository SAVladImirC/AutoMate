using Data.Models;
using Data.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformedServiceController : ControllerBase
    {
        private readonly PerformedServiceService _performedService;

        public PerformedServiceController(PerformedServiceService performedService)
        {
            _performedService = performedService;
        }

        [HttpGet("{id}")]
        public async Task<Response> GetById(int id)
        {
            return await _performedService.GetById(id);
        }
    }
}
