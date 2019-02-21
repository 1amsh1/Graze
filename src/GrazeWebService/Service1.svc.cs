using GrazeWebService.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace GrazeWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static List<Item> items = new List<Item>()
        {
            new Item(){ Category=1, Name="Tomato",Price=10,Filename="TomatoImg" },
            new Item(){Category=1, Name="Onion", Price=30,Filename="OnionImg" },
            new Item(){Category=1, Name="Banana", Price=25,Filename="BananaImg" },
            new Item(){Category=1, Name="Apple", Price=20,Filename="AppleImg"},
            new Item(){Category=2, Name="Jeera", Price=45,Filename="JeeraImg"},
            new Item(){Category=2, Name="Mustard", Price=40,Filename="MustardImg"},
            new Item(){Category=2, Name="Toor dal", Price=80,Filename="ToorImg"},
            new Item(){Category=2, Name="Moong dal", Price=75,Filename="MoongImg"},
        };
        static List<Recipe> recipes = new List<Recipe>();

        public Boolean AddRecipe(String n,List<string> ItemsforRecipe)
        {
            Boolean success = false; 
            try
            {
                List<Item> AllItems = new List<Item>();
                foreach(string s in ItemsforRecipe)
                {
                    foreach(Item i in items)
                    {
                        if (s.Equals(i.Name))
                        {
                            Item newItem = new Item(i.Category, i.Name, i.Price, i.Filename);
                            AllItems.Add(newItem);
                            break;
                        }
                        else
                            success = true;
                    }
                }
                Recipe r = new Recipe(n, AllItems);
                recipes.Add(r);
                success = true;
            }
            catch(Exception e)
            {
                success = false;
            }
            return success;
        }

        public List<Item> GetItemsByCategory(int c)
        {
            List<Item> itemsByCategory = new List<Item>();
            foreach(Item i in items)
            {
                if(i.Category==c)
                {
                    itemsByCategory.Add(i);
                }
            }
            return itemsByCategory;
        }

        public List<Item> GetItemsByRecipe(string s)
        {
            List<Item> ItemsByRecipe = new List<Item>();
            foreach (Recipe r in recipes)
            {
                if(r.Name.Equals(s))
                {
                    ItemsByRecipe = r.Ingredients;
                }
            }
            return ItemsByRecipe;
        }

        public byte[] GetImage(String filename)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/DataModel/GrazeImages/"+filename+".jpg");
            byte[] b = File.ReadAllBytes(path);
            return b;
        }
    }
}
