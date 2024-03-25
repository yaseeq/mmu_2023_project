using WebApplication1.Properties;

namespace WebApplication1
{
    public class Program
    {
        public class Switch
        {
            public string State { get; set; }
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        static async Task Main()
        {
            const string apiUrl = "http://localhost:5015/api/Switch/";

           
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
}

   
