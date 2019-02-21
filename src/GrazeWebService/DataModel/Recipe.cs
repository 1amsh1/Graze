using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GrazeWebService.DataModel
{
    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Item> Ingredients { get; set; }

        public Recipe(string n,List<Item>i)
        {
            Name = n;
            Ingredients = i;
        }
    }
}