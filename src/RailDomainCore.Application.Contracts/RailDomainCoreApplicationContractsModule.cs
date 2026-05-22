using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace RailDomainCore;

[DependsOn(typeof(AbpDddApplicationContractsModule))]
[DependsOn(typeof(RailDomainCoreDomainSharedModule))]
public class RailDomainCoreApplicationContractsModule : AbpModule
{
}
