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
