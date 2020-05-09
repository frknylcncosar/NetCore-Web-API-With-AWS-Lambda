using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaShoppingListWebApi.Models;
using LambdaShoppingListWebApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingListWebApi.Controllers
{
    
    [Route("api/[controller]")]
    

    public class ShoppingListController : Controller{

        private readonly IShoppingListService _shoppingListService;
        public ShoppingListController(IShoppingListService shoppingListService) {
            _shoppingListService = shoppingListService;
        }
        
        [HttpGet]
       
        public IEnumerable<ShoppingListModel> GetShoppingList() {
            var result = _shoppingListService.GetItemsFromShoppingList();
            return result;
        }
        [HttpPost]
        public IActionResult AddItemToShoppingList([FromBody] ShoppingListModel shoppingList) {

            _shoppingListService.AddItemsToShoppingList(shoppingList);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteItemsFromShoppingList([FromBody]ShoppingListModel shoppingList) {
            _shoppingListService.DeleteItemsFromShoppingList(shoppingList.ID);
            return Ok();
        }
    }
    
}