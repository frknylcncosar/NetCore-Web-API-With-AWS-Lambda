using LambdaShoppingListWebApi.Models;
using System.Collections.Generic;

namespace LambdaShoppingListWebApi.Services {
    public interface IShoppingListService {
        IEnumerable<ShoppingListModel> GetItemsFromShoppingList();
        void AddItemsToShoppingList(ShoppingListModel shoppingList);
        void DeleteItemsFromShoppingList(int id);
    }
}