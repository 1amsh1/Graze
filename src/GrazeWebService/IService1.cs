using GrazeWebService.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GrazeWebService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Boolean AddRecipe(String n, List<string> i);

        [OperationContract]
        List<Item> GetItemsByCategory(int c);

        [OperationContract]
        List<Item> GetItemsByRecipe(string s);

        [OperationContract]
        byte[] GetImage(String file);

    }

}
