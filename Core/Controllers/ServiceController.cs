using Microsoft.AspNetCore.Http;
using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("{id}")]
        public async Task<Response> GetById(int id)
        {
            return await _serviceService.GetById(id);
        }
    }
}
