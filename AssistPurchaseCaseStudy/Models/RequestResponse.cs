using System.Collections.Generic;


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
            this.LayerMembers = new string[] { "default1", "default2" };
            this.Layer = "default";
            this.ChoiceDictionary.Add("key1", this.LayerMembers);
            this.ChoiceDictionary.Add("key2", this.LayerMembers);
        }

        public RequestResponse(Dictionary<string, string[]> choices, string[] layerMembers, string nextLayer)
        {
            this.ChoiceDictionary = choices;
            this.LayerMembers = layerMembers;
            this.Layer = nextLayer;
        }
    }
}
