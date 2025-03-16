using Task_backend;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();            
        SeedData(host);
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    public static void SeedData(IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
                
           

        }
    }
}