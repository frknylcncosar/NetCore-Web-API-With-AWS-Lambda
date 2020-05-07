using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingListWebApi.Models {
    public class ContextDB {
        AmazonDynamoDBClient aws;
        public ContextDB() {
            var myCredentials = new BasicAWSCredentials("Application Key ID", "Secret Access Key");
            aws = new AmazonDynamoDBClient(myCredentials,RegionEndpoint.EUCentral1);
        }

        public List<string> GetTables() {
            var response = aws.ListTablesAsync();
            return response.Result.TableNames;
        }
        public void Insert(ShoppingListModel shoppingListModel) {
            var context = new DynamoDBContext(aws);
            context.SaveAsync<ShoppingListModel>(shoppingListModel).Wait();
            
        }
        public void Delete(int id) {
            var context = new DynamoDBContext(aws);
            
            List<ScanCondition> queryConditions = new List<ScanCondition>();
            queryConditions.Add(new ScanCondition("ID", ScanOperator.Equal, id));
            var queryResult = context.ScanAsync<ShoppingListModel>(queryConditions).GetRemainingAsync();
            ShoppingListModel shoppingList = queryResult.Result.First();
           context.DeleteAsync<ShoppingListModel>(shoppingList);
           
            
        }
        public IEnumerable<ShoppingListModel> GetItems() {
            int id = 0;
            var context = new DynamoDBContext(aws);
            List<ScanCondition> queryConditions = new List<ScanCondition>();
            queryConditions.Add(new ScanCondition("ID",ScanOperator.GreaterThan,id));
            var queryResult = context.ScanAsync<ShoppingListModel>(queryConditions).GetRemainingAsync();
            return queryResult.Result.ToList();

        }
    }
}
