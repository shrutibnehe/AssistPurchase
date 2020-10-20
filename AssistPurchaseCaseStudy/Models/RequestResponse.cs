using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchaseCaseStudy.Models
{
    public class RequestResponse
    {
        public Dictionary<string, string[]> ChoiceDictionary { get; set; }
        public string Layer { get; set; }
        public string[] LayerMembers { get; set; }

        public RequestResponse()
        {
            this.ChoiceDictionary = new Dictionary<string, string[]>();
            this.LayerMembers = new string[] { "LayerMem1", "LayerMem2" };
            this.Layer = "Layer3";
            this.ChoiceDictionary.Add("Layer1", this.LayerMembers);
            this.ChoiceDictionary.Add("Layer2", this.LayerMembers);
        }

        public RequestResponse(Dictionary<string, string[]> choices, string[] layerMembers, string nextLayer)
        {
            this.ChoiceDictionary = choices;
            this.LayerMembers = layerMembers;
            this.Layer = nextLayer;
        }
    }
}
