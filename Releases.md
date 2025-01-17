



# PluginCore-v0.8.5

## Updated

- Reference: plugincore-admin-frontend v0.3.0

# PluginCore-v0.8.4

## Updated

- PackageReference: PluginCore.IPlugins: 0.6.1

# PluginCore.IPlugins-v0.6.1

## Updated

- remove: `Newtonsoft.Json`
  - 设置的json格式化 使用 `System.Text.json`


# PluginCore-v0.8.3

## Fixed

- 当 `主程序 打包进入 1个dll 或 1个exe` 可能导致 插件重复引入 主程序已引入Assembly

# PluginCore-v0.8.2

## Fixed

- nuget 包中 `PluginCore.dll` 缺失 `Resources` 导致 #7 


# PluginCore-v0.8.1

## Fixed

- 用户头像 在某些时候url错误: 改为完全由前端提供

- RemoteFrontend 已更新


# PluginCore-v0.8.0

## Added

- `ITimeJobPlugin` 定时任务 激活

## Updated

- 命名空间 整理




# PluginCore.IPlugins-v0.6.0

## Added

- `ITimeJobPlugin` 定时任务

## Updated

- 命名空间 整理



# PluginCore.IPlugins-v0.5.0

## Added

- `IPluginFinder` 添加，并注入服务
- `ConfigureServicesOrder`, `ConfigureOrder` 添加，`ConfigureOrder` 应用

# PluginCore-v0.7.0

## Added

- `IPluginFinder` 注入服务

## Updated

-  `PluginApplicationBuilderManager`
   - 性能提升: 不再是每次在 middleware.invoke 时 build插件的middleware, 而是启用禁用时rebuild



# PluginCore.IPlugins-v0.4.0


## Added

- `IStartupXPlugin` 支持在运行时添加 `请求管道Middleware` , 热插拔 ( 实验阶段 )
   - 不同于 `IStartupPlugin` 必须启用后，重启站点


# PluginCore-v0.6.0

## Added

- 激活 `IStartupXPlugin`  的 `Configure(IApplicationBuilder app)`
   - 支持在运行时添加 `请求管道Middleware` , 热插拔 ( 实验阶段 )
   - 不同于 `IStartupPlugin` 必须启用后，重启站点
   - 暂不支持 `ConfigureServices(IServiceCollection services)`

# PluginCore-v0.5.1

## Fixed

- 当插件引用dll时, 插件Controller立即使用引用dll时，报错:找不到引用dll
  - 改变加载dll顺序: 先加载插件引用的dll, 再加载插件主dll

- 插件启用: 内部顺序 引起的插件未成功启用，但配置文件却已改变

## Updated

- IStartupPlugin 激活，进入实验阶段
  - 实现 `IStartupPlugin` 的插件 安装后，需先启用，再重启站点，即可激活 `IStartupPlugin`, 此类插件无法热插拔



# PluginCore.IPlugins-v0.3.0

## Added

- 插件sdk
  - 新的api


# PluginCore-v0.5.0

## Added

- 插件sdk
  - 新的api

## Updated

- 前端内嵌式资源 改为使用 npm, 不再使用 `PluginCoreAdmin`, 只有 `LocalFolder` 模式才使用此文件夹



# PluginCore-v0.4.0

## Added

- 支持 嵌入式资源 方式引入前端

## Updated

- PluginCore.Config.json 部分配置属性 改变
   - PluginCore.Config.json 前端配置 改为 前端模式 ( `FrontendMode` )




# PluginCore.IPlugins-v0.2.0

## Added

- plugin 支持加载插件 wwwroot 文件夹下的 html前端等




# PluginCore-v0.3.1

## Fixed

- System.InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found. The default schemes can be set using either AddAuthentication(string defaultScheme) or AddAuthentication(Action<AuthenticationOptions> configureOptions).
  - Fixed #4 


# PluginCore-v0.3.0

## Added

- plugin 支持加载插件 wwwroot 文件夹下的 html前端等



# PluginCore-v0.2.0


## Added

- 支持加载远程前端, 使用 jsdelivr
   - https://cdn.jsdelivr.net/gh/yiyungent/plugincore-admin-fronted@0.1.2/dist-cdn/



# PluginCore.IPlugins-v0.1.0

## 基本的 Plugin 接口

- IPlugin
- BasePlugin
- 基本 辅助类


# PluginCore-v0.1.0

## Added

- 加载本地 前端



