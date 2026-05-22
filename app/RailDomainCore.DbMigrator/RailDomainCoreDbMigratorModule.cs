using RailDomainCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace RailDomainCore.DbMigrator;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
[DependsOn(typeof(RailDomainCoreEntityFrameworkCoreModule))]
public class RailDomainCoreDbMigratorModule : AbpModule
{
}
