using SIS.MvcFramework.Routing;

namespace SIS.MvcFramework
{
    public interface IMvcApplication
    {
        void Configure(IServerRoutingTable serverRoutingTable);

        void ConfigureServices(SIS.MvcFramework.DependencyContainer.IServiceProvider serviceProvider);
    }
}
