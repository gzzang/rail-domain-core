using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RailDomainCore;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(RailDomainCoreApplicationContractsModule))]
[DependsOn(typeof(RailDomainCoreDomainModule))]
public class RailDomainCoreApplicationModule : AbpModule
{
}
