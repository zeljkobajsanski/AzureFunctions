using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Autofac;
using CheckDigitAlg;
using CheckDigitAlg.Impl;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CheckDigitFunction
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public static class GetCheckDigit
    {
        [FunctionName("GetCheckDigit")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, TraceWriter log,
            [Inject()] ICheckDigitAlgorithm checkDigitAlgorithm)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string input = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "input", true) == 0)
                .Value;

            if (input == null)
                return req.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide input parameter");

            try
            {
                var checkDigit = checkDigitAlgorithm.CreateCheckDigit(input);
                return req.CreateResponse(HttpStatusCode.OK, checkDigit);
            }
            catch (System.Exception exc)
            {
                log.Error(exc.Message, exc);
                return req.CreateErrorResponse(HttpStatusCode.BadRequest, exc.Message);
            }
        }
    }
}
