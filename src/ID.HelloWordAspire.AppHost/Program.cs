public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var apiService = builder.AddProject<Projects.ID_HelloWordAspire_ApiService>("apiservice");

        builder.AddProject<Projects.ID_HelloWordAspire_Web>("webfrontend")
            .WithExternalHttpEndpoints()
            .WithReference(apiService)
            .WaitFor(apiService);

        builder.Build().Run();
    }
}
