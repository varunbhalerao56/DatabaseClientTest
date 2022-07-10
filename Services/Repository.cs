using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                Console.WriteLine("Data: " + endpointURL);
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



        public async Task<T> GetSingle(string endpointURL, List<DataItem> dataItems)
        {
            HttpClient client = new HttpClient();
            try
            {
                Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();

                foreach (var dataItem in dataItems)
                {
                    values.Add(dataItem.FieldName, dataItem.Value);
                }

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"http://localhost:5001/ollie-verse-prod/us-central1/{endpointURL}", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Dictionary<string, dynamic>? responseDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);

                string itemJson = JsonConvert.SerializeObject(responseDict!["data"], Newtonsoft.Json.Formatting.Indented);

                T? item = JsonConvert.DeserializeObject<T>(itemJson);

                Console.WriteLine("Data:" + endpointURL);
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


        public async Task GetSingleNoReturn(string endpointURL, List<DataItem> dataItems)
        {
            HttpClient client = new HttpClient();
            try
            {
                Dictionary<string, dynamic> values = new Dictionary<string, dynamic>();

                foreach (var dataItem in dataItems)
                {
                    values.Add(dataItem.FieldName, dataItem.Value);
                }

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"http://localhost:5001/ollie-verse-prod/us-central1/{endpointURL}", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                client.Dispose();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");

                client.Dispose();
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Dictionary<String, dynamic>>> GetAllJson(string endpointURL)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://localhost:5001/ollie-verse-prod/us-central1/{endpointURL}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Dictionary<string, dynamic>? responseDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);

                string usableItemJson = JsonConvert.SerializeObject(responseDict!["data"], Newtonsoft.Json.Formatting.Indented);

                List<Dictionary<String, dynamic>>? usableItemList = JsonConvert.DeserializeObject<List<Dictionary<String, dynamic>>>(usableItemJson);

                Console.WriteLine("Data: " + endpointURL);
                foreach (var item in usableItemList!)
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
    }


    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(string endpointURL);
        Task<T> GetSingle(string endpointURL, List<DataItem> dataItems);

        Task GetSingleNoReturn(string endpointURL, List<DataItem> dataItems);

        Task<List<Dictionary<String, dynamic>>> GetAllJson(string endpointURL);

    }
}