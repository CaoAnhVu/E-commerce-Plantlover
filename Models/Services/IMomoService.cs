using Cs_Plantlover.Models;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.ViewModels;
using Microsoft.AspNetCore.Http;
using Cs_Plantlover.Models.Momo;

namespace Cs_Plantlover.Services;

public interface IMomoService
{
    Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderDetails model);
    string CreatePaymentUrl(HttpContext httpContext, MomoExecuteResponseModel moMoModel);
    MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
}