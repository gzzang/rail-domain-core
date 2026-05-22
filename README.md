# RailDomainCore

RailDomainCore 是一个基于 **.NET 10**、**ABP**、**DDD 分层架构** 的示例项目，默认 UI 为 **Blazor Server**，数据库为 **PostgreSQL**，并提供 **Docker**、**GitHub Actions 托管 CI** 与 **本地自托管 Runner CD** 的基础流水线设计。

## 技术栈

- .NET 10.0
- ABP 10.4.0
- Blazor Server
- EF Core + PostgreSQL
- xUnit
- Docker / Docker Compose
- GitHub Actions（CI: GitHub-hosted / CD: self-hosted）

## 数据库约定

- 正式库：`rail_domain_core`
- 开发库：`rail_domain_core_dev`
- 测试库：`rail_domain_core_test`
- 用户名：通过环境变量 `DB_USER` 提供
- 密码：通过环境变量 `DB_PWD` 提供

默认连接串位于：

- `/home/runner/work/rail-domain-core/rail-domain-core/src/RailDomainCore.Blazor/appsettings.json`
- `/home/runner/work/rail-domain-core/rail-domain-core/app/RailDomainCore.DbMigrator/appsettings.json`

## 分层结构

- `src/RailDomainCore.Domain.Shared`：共享常量与 ABP Domain Shared 模块
- `src/RailDomainCore.Domain`：领域模型、聚合与仓储接口
- `src/RailDomainCore.Application.Contracts`：应用契约模块
- `src/RailDomainCore.Application`：应用模块
- `src/RailDomainCore.EntityFrameworkCore`：EF Core DbContext 与实体映射
- `src/RailDomainCore.Blazor`：Blazor Server UI 与 ABP 宿主
- `app/RailDomainCore.DbMigrator`：数据库迁移控制台程序
- `test/RailDomainCore.Domain.Tests`：领域模型单元测试

## 领域建模

- `Version`：单实体聚合，作为 `Train`、`Formation`、`Route` 的版本归属
- `Train`：聚合根，内部持有 `TrainStation` 子实体集合
- `Formation`：聚合根，绑定 `Version` 与 `Train`
- `Route`：聚合根，绑定 `Version`、`Train`、`Formation`
- `Station`：独立仓储共享实体，可被多个聚合复用

## 本地运行

```bash
dotnet restore /home/runner/work/rail-domain-core/rail-domain-core/RailDomainCore.slnx
dotnet build /home/runner/work/rail-domain-core/rail-domain-core/RailDomainCore.slnx
dotnet test /home/runner/work/rail-domain-core/rail-domain-core/RailDomainCore.slnx
```

启动 Blazor Server：

```bash
dotnet run --project /home/runner/work/rail-domain-core/rail-domain-core/src/RailDomainCore.Blazor/RailDomainCore.Blazor.csproj
```

执行数据库迁移：

```bash
dotnet run --project /home/runner/work/rail-domain-core/rail-domain-core/app/RailDomainCore.DbMigrator/RailDomainCore.DbMigrator.csproj
```

## Docker

```bash
docker compose up --build
```

将启动：

- `postgres:18.4-alpine`
- `redis:8.6-alpine`
- `rail-domain-core-migrator`
- `rail-domain-core-blazor`

## CI/CD

仓库内置以下工作流：

- `/home/runner/work/rail-domain-core/rail-domain-core/.github/workflows/ci.yml`
  - 运行于 GitHub 托管 `ubuntu-latest`
  - 执行 restore / build / test
  - 验证 Docker 镜像可构建
- `/home/runner/work/rail-domain-core/rail-domain-core/.github/workflows/cd.yml`
  - 由 `ci` 成功后触发
  - 仅在 `main` / `master` 分支执行
  - 运行于本地自托管 Windows x64 Runner
  - 从 Actions Variables / Secrets 读取 `DB_USER` / `DB_PWD`
  - 通过 `docker compose up -d --build --remove-orphans` 执行部署
