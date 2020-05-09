using LambdaShoppingListWebApi.Models;
using System.Collections.Generic;

namespace LambdaShoppingListWebApi.Services {
    public interface IShoppingListService {
        IEnumerable<ShoppingListModel> GetItemsFromShoppingList();
        void AddItemsToShoppingList(ShoppingList shoppingList);
        void DeleteItemsFromShoppingList(int id);
    }
}