using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RailDomainCore;

[DependsOn(typeof(AbpDddDomainModule))]
[DependsOn(typeof(RailDomainCoreDomainSharedModule))]
public class RailDomainCoreDomainModule : AbpModule
{
}
