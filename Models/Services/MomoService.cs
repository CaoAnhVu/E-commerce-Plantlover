using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Cs_Plantlover.Models.Momo;
using Cs_Plantlover.Infrastructure;
using Cs_Plantlover.ViewModels;
using Microsoft.AspNetCore.Http;
using Twilio.TwiML.Voice;
using RestSharp;
using Cs_Plantlover.Models;
using Cs_Plantlover.Services;

namespace Cs_Plantlover.Services
{
    public class MomoService : IMomoService
    {
        private readonly IOptions<MomoOptionModel> _options;

        public MomoService(IOptions<MomoOptionModel> options)
        {
            _options = options;
        }

        public async  Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderDetails model )
        {
            model.OrderId = ((int)DateTime.UtcNow.Ticks) ;

            // Ensure that OrderHeader is correctly assigned
            model.OrderHeader = new OrderHeader
            {
                // Adjust properties as per your OrderHeader class
                // Example:
                // OrderDescription = "Đơn hàng: " + model.Id + ". Nội dung: " + model.OrderHeader
            };

            var rawData =
                $"partnerCode={_options.Value.PartnerCode}&accessKey={_options.Value.AccessKey}&requestId={model.OrderId}&amount={model.Price}&ordercount={model.Count}&orderId={model.OrderId}&orderInfo={model.MaSP}&returnUrl={_options.Value.ReturnUrl}&notifyUrl={_options.Value.NotifyUrl}&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.OrderId,
                amount = model.Price.ToString(),
                count = model.Count.ToString(),
                orderInfo = model.MaSP,
                requestId = model.OrderId,
                extraData = "",
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<MomoCreatePaymentResponseModel>(response.Content);
        }

        public string CreatePaymentUrl(HttpContext httpContext, MomoExecuteResponseModel moMoModel)
        {
            throw new NotImplementedException();
        }

        public  MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection)
        {
            var orderId = int.Parse(collection.First(s => s.Key == "orderId").Value.ToString());
            var fullName = collection.First(s => s.Key == "fullName").Value.ToString();
            var description = collection.First(s => s.Key == "description").Value.ToString();
            var amount = int.Parse(collection.First(s => s.Key == "amount").Value.ToString());

            return new MomoExecuteResponseModel()
            {
                OrderId = orderId,
                FullName = fullName,
                Description = description,
                Amount = amount,
            };
        }

        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }
    }
}
