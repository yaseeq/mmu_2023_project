using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        const string apiUrl = "http://localhost:5015/switch/";

        // Отправляем GET запрос для получения текущего состояния
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string state = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Current switch state: " + state);
            }
            else
            {
                Console.WriteLine("Failed to get switch state");
            }
        }

        // Отправляем POST запрос для установки нового состояния (например, "on")
        using (HttpClient client = new HttpClient())
        {
            var content = new StringContent("{\"State\":\"on\"}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Switch state set to 'on'");
            }
            else
            {
                Console.WriteLine("Failed to set switch state");
            }
        }
    }
}