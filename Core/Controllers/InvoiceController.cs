using Data.Responses;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("client/{id}")]
        public async Task<Response> GetAllInvoicesForUser(int id)
        {
            return await _invoiceService.GetAllInvoicesForUser(id);
        }

        [HttpGet("get-pdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            return await _invoiceService.GetPdf(id);
        }
    }
}
