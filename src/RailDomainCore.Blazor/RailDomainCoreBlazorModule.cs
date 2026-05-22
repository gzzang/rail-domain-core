using Microsoft.Extensions.DependencyInjection;
using RailDomainCore.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Components.Server;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace RailDomainCore.Blazor;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpAspNetCoreComponentsServerModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
[DependsOn(typeof(RailDomainCoreApplicationModule))]
[DependsOn(typeof(RailDomainCoreEntityFrameworkCoreModule))]
public class RailDomainCoreBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = RailDomainCoreConsts.MultiTenancyEnabled;
        });
    }
}
