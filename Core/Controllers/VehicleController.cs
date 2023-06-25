using Data.Models;
using Data.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("{id}")]
        public async Task<Response> GetById(int id)
        {
            return await _vehicleService.GetById(id);
        }

        [HttpGet("user/{id}")]
        public async Task<Response> GetVehiclesForUser(int id)
        {
            return await _vehicleService.GetVehiclesForUser(id);
        }
    }
}
