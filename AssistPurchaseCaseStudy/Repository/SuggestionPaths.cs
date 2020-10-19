using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace AssistPurchaseCaseStudy.Models
{
    public class SuggestionPaths
    {
        private readonly string _question1 = "Features";
        private readonly List<string> _options1 = new List<string>() { "Touch_Screen", "Handle", "Alarm", "Battery" };
        public Dictionary<string, List<string>> quesDictionary = new Dictionary<string, List<string>>();
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



        public string Question1
        {
            get => _question1;
        }

        public List<string> Options1
        {
            get => _options1;
        }

        public SuggestionPaths()
        {
            quesDictionary.Add(Question1, Options1);
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
