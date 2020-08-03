using REST_Client.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace REST_Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            runAsync().GetAwaiter().GetResult();
        }

        static async Task runAsync()
        {
            HttpClient httpClient = new HttpClient();
            // URL base
            httpClient.BaseAddress = new Uri("https://localhost:44364/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Agregar el tipo de dato de la petición
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Agregar un JWT a la petición
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI1ZGFiZmNhNi00NzMzLTQ4YjktYTVmMy0zN2UwYzkyYTFhYTAiLCJuYW1laWQiOiJiNWQyMzNmMC02ZWMyLTQ5NTAtOGNkNy1mNDRkMTZlYzg3OGYiLCJub21icmUiOiJOb21icmUgVXN1YXJpbyIsImFwZWxsaWRvcyI6IkFwZWxsaWRvcyBVc3VhcmlvIiwiZW1haWwiOiJlbWFpbC51c3VhcmlvQGRvbWluaW8uY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW5pc3RyYWRvciIsIkVtcGxveWVlSWQiOiJkb3MiLCJuYmYiOjE1OTYzMzIyMjgsImV4cCI6MTU5NjQxODYyOCwiaXNzIjoid3d3LnJhZmFlbGFjb3N0YS5uZXQiLCJhdWQiOiJ3d3cucmFmYWVsYWNvc3RhLm5ldC9hcGkvbWl3ZWJhcGkifQ.IDvy-Gu9V2wn-C-D6OWoAvD4CGsZbwT-mw4qiuqTZkg");

            // Petición GET
            Client client = new Client(httpClient);
            string pathGetRequest = "pais/politica";
            var resGet = await client.getRequest(pathGetRequest);

            // Petición POST
            GeneroPost generoPost = new GeneroPost { nombre = "MeroMero" };
            string pathPostRequest = "generos";
            //var resPost = await client.postRequest(generoPost, pathPostRequest);

            // Petición PUT
            GeneroPut generoPut = new GeneroPut { id = 4, nombre = "Salomero" };
            string pathPutRequest = "generos";
            //var resPut = await client.putRequest(generoPut, pathPutRequest);

            // Petición DELETE
            string pathDeleteRequest = "generos";
            string delete = "17";
            //var resDelete = await client.deleteAsync(pathDeleteRequest, delete);
        }
    }
}
