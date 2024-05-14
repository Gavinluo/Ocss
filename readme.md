### 在线选课系统

我们在这个代码仓库里会从0-1的搭建一个在线选课系统

### 安装Vs2022
https://visualstudio.microsoft.com/zh-hans/vs/   下载 Community 版本，安装

### 下载代码
- 点击右上角Code，点击 Download Zip，下载源代码
- 或者使用Git客户端工具进行下载，这里就不介绍了，想学习的同学可以去搜索一下Git使用方法

### 运行代码
双击Ocss目录的 Ocss.sln 解决方案，F5 运行或者点击 运行绿色箭头

### 代码目录说明

- `DemoEFConnectDB` EF访问数据库Demo程序
- `Html` 后端管理整套html模板
- `ManageHTML` 选课系统所需要使用的html模板
- `Ocss.Service` 选课系统的服务端
- `Ocss.Web` 选课系统的Web
- `StudyInfomationSpider` 慕课网学习信息爬虫



### 通过 生成 DbContext对象
VS菜单中的 工具->NuGet包管理器 ->程序包管理器控制台，安装以下内容

- 在控制台中输入以下命令并按Enter键：
- `Install-Package Microsoft.EntityFrameworkCore -Version 8.0.4`
- 等待安装完成后，输入以下命令并按Enter键：
- `Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.4`
- 等待安装完成后，输入以下命令并按Enter键：
- `Install-Package Pomelo.EntityFrameworkCore.MySql -Version 8.0.2`
- 等待安装完成后，您就可以开始使用这些包了。

VS菜单中的 工具->NuGet包管理器 ->程序包管理器控制台 输入一下命令
```C#
Scaffold-DbContext "persist security info=True;data source=rm-8vbrx1u4mnqb94o2h2o.rwlb.zhangbei.rds.aliyuncs.com;port=3306;initial catalog=04010018;user id=student;password=student;character set=utf8;allow zero datetime=true;convert zero datetime=true;pooling=true;maximumpoolsize=3000" Pomelo.EntityFrameworkCore.MySql -OutputDir DatabaseModels
```

会在你的解决方案中自动生成 DatabaseModels目录和类文件

如果你使用的是 JetBrain Rider 开发工具，DbContext对象生成使用
```dotnet ef dbcontext scaffold "Server=数据库地址;Integrated Security=true;" Pomelo.EntityFrameworkCore.MySql -c MyDBContext```
参考：https://blog.jetbrains.com/dotnet/2017/08/09/running-entity-framework-core-commands-rider/
