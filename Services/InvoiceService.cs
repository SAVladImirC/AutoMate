using Data.Models;
using Data.Responses;
using Repositories;
using Data.ValueObjects;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;

namespace Services
{
    public class InvoiceService
    {
        private readonly InvoiceRepository _invoiceRepository;
        private readonly PerformedServiceRepository _performedServiceRepository;

        public InvoiceService(InvoiceRepository invoiceRepository, PerformedServiceRepository performedServiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _performedServiceRepository = performedServiceRepository;
        }

        public async Task<Response> GetAllInvoicesForUser(int userId)
        {
            try
            {
                List<Invoice> invoices = await _invoiceRepository.FindAll(i => i.ClientId == userId);
                return new SuccessResponse<List<Invoice>>() { Data = invoices };
            }
            catch (Exception)
            {
                return new ErrorResponse() { Message = "Се случи грешка" };
            }
        }
        public async Task<IActionResult?> GetPdf(int id)
        {
            try
            {
                Invoice? invoice = await _invoiceRepository.FindSingle(i => i.Id == id);
                if (invoice == null) return null;
                var fileStream = new FileStream(invoice.Path, FileMode.Open, FileAccess.Read);
                var response = new FileStreamResult(fileStream, "application/pdf");

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
