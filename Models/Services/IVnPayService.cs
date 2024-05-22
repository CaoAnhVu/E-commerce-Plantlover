using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Cs_Plantlover.Models.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);
        Cs_Plantlover.Infrastructure.VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}