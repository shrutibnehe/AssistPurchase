using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchaseCaseStudy.Models;

namespace AssistPurchaseCaseStudy.Repository
{
    public class RequestResponseHandling : IRequestResponseHandling
    {

        public RequestResponse GetSampleRequestResponse()
        {
            Models.RequestResponse sendResponse = new RequestResponse();
            return sendResponse;
        }
    }
}
