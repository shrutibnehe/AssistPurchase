using System.Collections.Generic;
using System.Linq;


namespace AssistPurchaseCaseStudy.Models
{
    public class SuggestionPaths
    {
        public Dictionary<string, List<string>> quesDictionary = new Dictionary<string, List<string>>();

        private readonly string _question1 = "Features";
        private readonly List<string> _featuresMap = new List<string>() { "Touch_Screen", "Handle", "Alarm", "Battery" };
        
        private readonly List<string> _tsMap = new List<string>() { "Only Spo2", "ESN", "Resp", "CO2", "Others" };
        private readonly List<string> _handleMap = new List<string>() { "ESN", "Resp", "CO2" };
        private readonly List<string> _alarmMap = new List<string>() { "Additional Display", "ESN", "Resp", "CO2" };
        private readonly List<string> _batteryMap = new List<string>() { "Only Spo2", "ESN", "Resp", "CO2", "Others" };

        private readonly List<string> _onlySPO2Map = new List<string>() { "10-15" };
        private readonly List<string> _ESNMap = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _respMap = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _CO2Map = new List<string>() { "upto 10", "10-15", "above 15" };
        private readonly List<string> _othersMap = new List<string>() { "upto 10" };
        private readonly List<string> _addDisplayMap = new List<string>() { "above 15" };

        private readonly List<string> _DisplayMap = new List<string>() { "End" };

        private readonly Dictionary<string, string> layerHierarchy = new Dictionary<string, string>()
            {{"Features", "Services"}, {"Services", "DisplaySize"}, {"DisplaySize", "lastLayer"}};

        public readonly List<string> listOfLayers = new List<string>() { "Features", "Services", "DisplaySize", "lastLayer" };

        public Dictionary<string, List<string>> ValidLayerMembers = new Dictionary<string, List<string>>();


        public SuggestionPaths()
        {
            quesDictionary.Add(_question1, _featuresMap);
            quesDictionary.Add("Touch_Screen", _tsMap);
            quesDictionary.Add("Handle", _handleMap);
            quesDictionary.Add("Alarm", _alarmMap);
            quesDictionary.Add("Battery", _batteryMap);
            quesDictionary.Add("Only Spo2", _onlySPO2Map);
            quesDictionary.Add("ESN", _ESNMap);
            quesDictionary.Add("Resp", _respMap);
            quesDictionary.Add("CO2", _CO2Map);
            quesDictionary.Add("Additional Display", _addDisplayMap);
            quesDictionary.Add("Others", _othersMap);
            quesDictionary.Add("upto 10", _DisplayMap);
            quesDictionary.Add("10-15", _DisplayMap);
            quesDictionary.Add("above 15", _DisplayMap);

            ValidLayerMembers.Add(_question1, _featuresMap);
            ValidLayerMembers.Add("Services", new List<string>() { "Only Spo2", "Additional Display", "ESN", "Resp", "CO2", "Others" });
            ValidLayerMembers.Add("DisplaySize", new List<string>() { "upto 10", "10-15", "above 15" });
            ValidLayerMembers.Add("lastLayer", new List<string>() { "End" });
        }


        public string NextLayer(string previousLayer)
        {
            if (layerHierarchy.ContainsKey(previousLayer))
            {
                return layerHierarchy[previousLayer];
            }
            else
            {
                return "Invalid Input, layer not found";
            }
        }

        public string[] NextLayerMembers(string[] layerResponse)
        {
            var returnObjList = new List<string>();
            var lst = new List<string>();
            foreach (string response in layerResponse)
            {
                if (quesDictionary.ContainsKey(response))
                {
                    lst = quesDictionary[response];
                }

                returnObjList = returnObjList.Union(lst).ToList();
            }

            return returnObjList.ToArray();
        }
    }
}
