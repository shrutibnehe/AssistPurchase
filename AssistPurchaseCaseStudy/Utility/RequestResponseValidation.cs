using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchaseCaseStudy.Models;

namespace AssistPurchaseCaseStudy.Utility
{
    public class RequestResponseValidation
    {
        public bool IsRequestResponseCorrect(RequestResponse requestResponse)
        {
            var suggestionPathObj = new SuggestionPaths();
            if(suggestionPathObj.listOfLayers.Contains(requestResponse.Layer))
            {
                foreach(var layermember in requestResponse.LayerMembers)
                {
                    if (!suggestionPathObj.ValidLayerMembers[requestResponse.Layer].Contains(layermember))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool IsGetProductRequestCorrect(RequestResponse requestResponse)
        {
            if(requestResponse.ChoiceDictionary.Count!=0)
            {
                return true;
            }
            return false;
        }
    }
}
