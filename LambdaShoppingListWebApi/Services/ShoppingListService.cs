using LambdaShoppingListWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingListWebApi.Services {
    public class ShoppingListService : IShoppingListService {
        private readonly ContextDB _contextDB = new ContextDB();
 
        public void AddItemsToShoppingList(ShoppingListModel shoppingList) {
            
            ShoppingListModel shoppingListModel = new ShoppingListModel {
                ID = shoppingList.ID,
                ShoppingList = new ShoppingList {
                    Name = shoppingList.ShoppingList.Name,
                    Quantity = shoppingList.ShoppingList.Quantity
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
