using Newtonsoft.Json;
using Northwind.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EF.Logic
{
    public class FakeStoreLogic
    {
        public async Task<List<FakeStoreAPI>> GetProducts()
        {
            string apiUrl = "https://fakestoreapi.com/products";
            HttpClient httpClient = new HttpClient();

            try
            {
                string responseJson = await httpClient.GetStringAsync(apiUrl);

                List<FakeStoreAPI> products = JsonConvert.
                    DeserializeObject<List<FakeStoreAPI>>(responseJson);

                return products;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
