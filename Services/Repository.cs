using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseClientTest.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<List<T>> GetAll(string endpointURL)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://localhost:5001/ollie-verse-prod/us-central1/{endpointURL}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Dictionary<string, dynamic>? responseDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);

                string usableItemJson = JsonConvert.SerializeObject(responseDict!["data"], Newtonsoft.Json.Formatting.Indented);

                List<T>? usableItemList = JsonConvert.DeserializeObject<List<T>>(usableItemJson);

                Console.WriteLine("Data");
                foreach (T item in usableItemList!)
                {
                    Console.WriteLine(item.ToString());
                }
                client.Dispose();

                return usableItemList!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");

                client.Dispose();
                throw new Exception(e.Message);
            }
        }


        public async Task<T> GetSingle(string endpointURL, string fieldName, string documentId)
        {
            HttpClient client = new HttpClient();
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string> { { fieldName, documentId }, };

                FormUrlEncodedContent content = new FormUrlEncodedContent(values);

                HttpResponseMessage response = await client.PostAsync($"http://localhost:5001/ollie-verse-prod/us-central1/{endpointURL}", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Dictionary<string, dynamic>? responseDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);

                string itemJson = JsonConvert.SerializeObject(responseDict!["data"], Newtonsoft.Json.Formatting.Indented);

                T? item = JsonConvert.DeserializeObject<T>(itemJson);

                Console.WriteLine("Data");
                Console.WriteLine(item?.ToString());

                client.Dispose();

                return item!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");

                client.Dispose();
                throw new Exception(e.Message);
            }
        }
    }

    public interface IRepository<T> where T : class
    {
        // GetAll()
        Task<List<T>> GetAll(string endpointURL);
        Task<T> GetSingle(string endpointURL, string fieldName, string documentId);
        // GetIdsOwnedByPlayer(int playerId)

        // AddToPlayer(int something, int playerId)
        // AddToPlayer(int playerId)
    }
}