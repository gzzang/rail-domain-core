using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RailDomainCore;

[DependsOn(typeof(AbpDddDomainSharedModule))]
public class RailDomainCoreDomainSharedModule : AbpModule
{
}
