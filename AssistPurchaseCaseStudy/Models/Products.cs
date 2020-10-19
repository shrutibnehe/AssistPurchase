using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchaseCaseStudy.Models
{
    public class Products
    {
        //changed
        public string ID { get; set; }
        public string Name { get; set; }
        public string[] Features { get; set; }
        public string[] Services { get; set; }
        public string DisplaySize { get; set; }
        public List<string> OtherInfo { get; set; }

        public Products(string id, string name, string[] features, string[] services, string displaySize)
        {
            this.ID = id;
            this.Name = name;
            this.Features = features;
            this.Services = services;
            this.DisplaySize = displaySize;
            this.OtherInfo = default(List<string>);
        }

        public Products()
        {
            this.ID = default(string);
            this.Name = default(string);
            this.Features = default(string[]);
            this.Services = default(string[]);
            this.DisplaySize = default(string);
            this.OtherInfo = default(List<string>);
        }
    }
}
