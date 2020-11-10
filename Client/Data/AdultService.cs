using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class AdultService : IAdultsService
    {
        
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public AdultService()
        {
            client = new HttpClient();
        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/AdultList");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<HttpStatusCode> AddAdultAsync(Adult adult)
        {
            string adultSerialized = JsonSerializer.Serialize(adult);

            StringContent content = new StringContent(
                adultSerialized,
                Encoding.UTF8,
                MediaTypeNames.Application.Json
            );
            HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:5003/AdultList", content);
            return responseMessage.StatusCode;
        }

        public async Task RemoveAdultAsync(int Id)
        {
            await client.DeleteAsync($"{uri}/AdultList/{Id}");
        }
    }
}