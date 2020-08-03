using REST_Client.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST_Client
{
    class Client
    {
        private readonly HttpClient _httpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> getRequest(string path)
        {
            object product = null;
            var ff = _httpClient.BaseAddress;
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            HttpStatusCode code = response.StatusCode;
            if (code == HttpStatusCode.OK)
            {
                // Para checar la respuesta de los Codigos de estado
            }
            if (response.IsSuccessStatusCode)
            {
                // Para usar ReadAsSync Install-Package Microsoft.AspNet.WebApi.Client
                product = await response.Content.ReadAsAsync<object>();
            }
            return product;
        }

        public async Task<Uri> postRequest<T>(T generoPost, string path) where T : class
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync<T>(
                path, generoPost);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
            //return response.StatusCode;
        }

        public async Task<object> putRequest<T>(T generoPut, string path) where T : IModel, new()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync(
                $"{path}/{generoPut.id}", generoPut);
                response.EnsureSuccessStatusCode();
                return new { Status = "Updated" };
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return new { Status = "NO exists" };
            }  
        }

        public async Task<HttpStatusCode> deleteAsync(string path, string id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(
                $"{path}/{id}");
            return response.StatusCode;
        }
    }
}
