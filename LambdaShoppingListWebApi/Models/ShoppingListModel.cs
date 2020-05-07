
using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingListWebApi.Models {
    [DynamoDBTable("ShoppingListModel")]
    public class ShoppingListModel {
        [DynamoDBHashKey]
        public int ID { get; set; }
        public ShoppingList ShoppingList { get; set; }


    }
    public class ShoppingList {
        public string Name { get; set; }
        public int Quantity { get; set; }
       
    }
}
