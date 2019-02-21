using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GrazeWebService.DataModel
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public int Category { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string Filename { get; set; }

        public Item(int c, string n, double p, string f)
        {
            Category = c;
            Name = n;
            Price = p;
            Filename = f;
        }

        public Item()
        {
        }
    }

}