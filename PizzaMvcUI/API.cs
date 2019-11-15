using Microsoft.AspNetCore.Mvc;
using PizzaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PizzaMvcUI
{
    //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public static class API
    {
        static readonly HttpClient client = new HttpClient();
        static API()
        {
            client.BaseAddress = new Uri("http://krazpizza.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<CrustTypes>> GetCrusts()
        {
            IEnumerable<CrustTypes> crusts = null;
            HttpResponseMessage response = await client.GetAsync("api/CrustTypes");
            if (response.IsSuccessStatusCode)
            {
                crusts = await response.Content.ReadAsAsync<IEnumerable<CrustTypes>>();
            }
            return crusts;
        }

        public static async Task<CrustTypes> GetCrust(int id)
        {
            CrustTypes crust = null;
            HttpResponseMessage response = await client.GetAsync($"api/CrustTypes/{id}");
            if (response.IsSuccessStatusCode)
            {
                crust = await response.Content.ReadAsAsync<CrustTypes>();
            }
            return crust;
        }

        public static async Task<int> Login(LoginCredentials credentials)
        {
            var response = await client.PostAsJsonAsync($"api/Customers/Login", credentials);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            return -1;
        }
    }
}
