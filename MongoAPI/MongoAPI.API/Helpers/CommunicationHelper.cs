using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MongoAPI.API.Helpers
{
    public class CommunicationHelper
    {
        public static HttpResponseMessage GetException(Exception except, HttpRequestMessage requestMessage)
        {
            var oResponse = new HttpResponseMessage();

            switch (except)
            {
                case HttpResponseException httpResponseException:
                    oResponse = requestMessage.CreateErrorResponse(HttpStatusCode.NotFound, httpResponseException);
                    oResponse.Headers.Add("x-status-reason", "Response Error");
                    break;
                case FormatException formatException:
                    oResponse = requestMessage.CreateErrorResponse(HttpStatusCode.Forbidden, formatException);
                    oResponse.Headers.Add("x-status-reason", "Format Error");
                    break;
                case TimeoutException timeoutException:
                    oResponse = requestMessage.CreateErrorResponse(HttpStatusCode.GatewayTimeout, timeoutException);
                    oResponse.Headers.Add("x-status-reason", "Timeout Error");
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    oResponse = requestMessage.CreateErrorResponse(HttpStatusCode.Unauthorized, unauthorizedAccessException);
                    oResponse.Headers.Add("x-status-reason", "Unauthorized");
                    break;
                case ArgumentException argumentException:
                    oResponse = requestMessage.CreateResponse(HttpStatusCode.RequestTimeout, except);
                    oResponse.Headers.Add("x-status-reason", "Argument Error");
                    break;
                default:
                    oResponse = requestMessage.CreateErrorResponse(HttpStatusCode.InternalServerError, except);
                    oResponse.Headers.Add("x-status-reason", "Exception Error");
                    break;
            }

            return oResponse;
        }

        public static HttpResponseMessage GetHttpResponseMessage(HttpRequestMessage pRequestMessage, object response)
        {
            HttpResponseMessage oResponse = null;
            if (response != null || (int)response > 0)
            {
                oResponse = pRequestMessage.CreateResponse(HttpStatusCode.OK, response);
                oResponse.Headers.Add("x-status-reason", "Records Found");
            }
            else
            {
                oResponse = pRequestMessage.CreateResponse(HttpStatusCode.NoContent);
                oResponse.Headers.Add("x-status-reason", "No Data");
            }

            return oResponse;
        }
    }
}