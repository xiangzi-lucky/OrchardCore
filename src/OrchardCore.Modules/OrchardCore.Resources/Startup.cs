using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.DisplayManagement.Liquid;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;
using OrchardCore.Resources.Liquid;

namespace OrchardCore.Resources
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<LiquidViewOptions>(o =>
            {
                o.LiquidViewParserConfiguration.Add(parser => parser.RegisterParserTag("link", parser.ArgumentsListParser, LinkTag.WriteToAsync));
                o.LiquidViewParserConfiguration.Add(parser => parser.RegisterParserTag("script", parser.ArgumentsListParser, ScriptTag.WriteToAsync));
                o.LiquidViewParserConfiguration.Add(parser => parser.RegisterParserTag("style", parser.ArgumentsListParser, StyleTag.WriteToAsync));
                o.LiquidViewParserConfiguration.Add(parser => parser.RegisterParserTag("resources", parser.ArgumentsListParser, ResourcesTag.WriteToAsync));
            });

            serviceCollection.AddScoped<IResourceManifestProvider, ResourceManifest>();
            serviceCollection.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
        }
    }
}
