using LambdaShoppingListWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingListWebApi.Services {
    public class ShoppingListService : IShoppingListService {
        private readonly ContextDB _contextDB = new ContextDB();
 
        public void AddItemsToShoppingList(ShoppingList shoppingList) {
            
            ShoppingListModel shoppingListModel = new ShoppingListModel {
                ID = (shoppingList.GetHashCode()),
                ShoppingList = new ShoppingList {
                    Name = shoppingList.Name,
                    Quantity = shoppingList.Quantity
                }
            };
            _contextDB.Insert(shoppingListModel);

        }

        public void DeleteItemsFromShoppingList(int id) {
            _contextDB.Delete(id);
        }

        public IEnumerable<ShoppingListModel> GetItemsFromShoppingList() {
           
           return _contextDB.GetItems();
        }
        




    }
}
