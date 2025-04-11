# Kunpo.Cur 项目

## 项目简介
Kunpo.Cur 是一个基于DDD（领域驱动设计）架构的企业级应用系统，采用前后端分离架构，实现了RBAC权限管理。

## 技术栈

### 后端技术栈
- 框架：.NET Core
- 架构：DDD（领域驱动设计）
- 权限：RBAC（基于角色的访问控制）
- ORM：SqlSugar
- 依赖注入：Autofac
- 数据库：SQL Server/MySQL
- API文档：Swagger
- 日志：Serilog（结构化日志，支持多种输出目标，性能优秀）
- 缓存：Redis

### 前端技术栈
- 框架：Vue 3
- UI框架：Ant Design Pro
- 状态管理：Pinia
- 国际化：Vue I18n
- 路由：Vue Router
- HTTP客户端：Axios
- 构建工具：Vite
- 图表：ECharts
- 代码规范：ESLint + Prettier

## 项目结构

### 后端项目结构
```
Kunpo.Cur/
├── src/
│   ├── Kunpo.Cur.Common/           # 公共层
│   │   ├── Constants/             # 常量定义
│   │   ├── Extensions/           # 扩展方法
│   │   ├── Helpers/              # 辅助类
│   │   ├── Models/               # 公共模型
│   │   ├── Utils/                # 工具类
│   │   └── Enums/                # 枚举定义
│   ├── Kunpo.Cur.Domain/           # 领域层
│   │   ├── Entities/              # 领域实体
│   │   ├── ValueObjects/          # 值对象
│   │   ├── Aggregates/            # 聚合根
│   │   └── DomainServices/        # 领域服务
│   ├── Kunpo.Cur.Application/      # 应用层
│   │   ├── Services/              # 应用服务
│   │   ├── DTOs/                  # 数据传输对象
│   │   └── Interfaces/            # 应用服务接口
│   ├── Kunpo.Cur.Infrastructure/   # 基础设施层
│   │   ├── Persistence/           # 持久化实现
│   │   ├── Identity/              # 身份认证
│   │   └── ExternalServices/      # 外部服务集成
│   └── Kunpo.Cur.WebApi/          # WebApi层
│       ├── Controllers/           # API控制器
│       ├── Middlewares/           # 中间件
│       └── Filters/               # 过滤器
```

### 前端项目结构
```
Kunpo.Cur.Web/
├── src/
│   ├── api/                       # API接口
│   ├── assets/                    # 静态资源
│   ├── components/                # 公共组件
│   ├── layouts/                   # 布局组件
│   ├── locales/                   # 国际化资源
│   ├── router/                    # 路由配置
│   ├── stores/                    # 状态管理
│   ├── utils/                     # 工具函数
│   ├── views/                     # 页面组件
│   ├── services/                  # 服务层
│   ├── models/                    # 数据模型
│   └── config/                    # 配置文件
├── config/                        # 项目配置
├── mock/                          # 模拟数据
└── public/                        # 公共资源
```

## 功能特性
- 基于RBAC的权限管理系统
- 多语言国际化支持
- 响应式布局设计
- 主题定制
- 数据可视化
- 系统监控
- 日志管理

## 开发环境要求
- .NET Core 7.0+
- Node.js 16+
- SQL Server 2019+ / MySQL 8.0+
- Redis 6.0+

## 快速开始

### 后端启动
1. 克隆项目
2. 配置数据库连接字符串
3. 运行数据库迁移
4. 启动项目

```bash
cd src/Kunpo.Cur.WebApi
dotnet run
```

### 前端启动
1. 安装依赖
2. 配置环境变量
3. 启动开发服务器

```bash
cd Kunpo.Cur.Web
npm install
npm run dev
```

## 部署说明
详细的部署文档请参考 [部署文档](./docs/deployment.md)

## 贡献指南
1. Fork 项目
2. 创建特性分支
3. 提交变更
4. 推送到分支
5. 创建 Pull Request

## 许可证
[MIT License](LICENSE)
