using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoCurrency.ApiActions
{
    internal class APIClient<T>
    {
        static HttpClient client = new HttpClient();
        static private string? responseBody;

        //for getting data from API
        static public async Task<T> GetGeneralAsync(string path = "https://api.coincap.io/v2/assets")
        {
            T? data = default;
            HttpResponseMessage? response = null;
            try
            {
                response = await client.GetAsync(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при виконанні запиту: {ex.Message}");
                Console.WriteLine($"Стек виклику: {ex.StackTrace}");
            }

            if (response == null)
            {
                throw new ArgumentNullException($"responce is null");
            }
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                data = JsonSerializer.Deserialize<T>(responseBody);
            }
            if (data == null)
            {
                throw new ArgumentNullException($"{typeof(T)} data is null");
            }
            return data;
        }

    }
}
