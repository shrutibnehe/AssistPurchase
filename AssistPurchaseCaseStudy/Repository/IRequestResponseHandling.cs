using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchaseCaseStudy.Models;


namespace AssistPurchaseCaseStudy.Repository
{
    public interface IRequestResponseHandling
    {
        public RequestResponse GetSampleRequestResponse();
    }
}
