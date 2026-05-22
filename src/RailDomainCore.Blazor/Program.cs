using Autofac.Extensions.DependencyInjection;
using RailDomainCore.Blazor.Components;
using Volo.Abp;

namespace RailDomainCore.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        await builder.AddApplicationAsync<RailDomainCoreBlazorModule>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAntiforgery();

        await app.InitializeApplicationAsync();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        await app.RunAsync();
    }
}
