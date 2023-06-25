using Microsoft.AspNetCore.Http;
using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStationController : ControllerBase
    {
        private readonly ServiceStationService _serviceStationService;

        public ServiceStationController(ServiceStationService serviceStationService)
        {
            _serviceStationService = serviceStationService;
        }

        [HttpGet]
        public async Task<Response> GetAll()
        {
            return await _serviceStationService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Response> GetById(int id)
        {
            return await _serviceStationService.GetById(id);
        }
    }
}