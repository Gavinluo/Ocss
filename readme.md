### 在线选课系统

我们在这个代码仓库里会从0-1的搭建一个在线选课系统

### 安装Vs2022
https://visualstudio.microsoft.com/zh-hans/vs/   下载 Community 版本，安装

### 下载代码
点击右上角Code，点击 Download Zip，下载源代码


### 运行代码
双击 sln 解决方案，F5 运行或者点击 运行绿色箭头



### 通过 生成 DbContext对象
VS菜单中的 工具->NuGet包管理器 ->管理解决方案的Nuget程序包 ，安装以下内容
Microsoft.EntityFrameworkCore  3.1.25
Microsoft.EntityFrameworkCore.Tools   3.1.25
Pomelo.EntityFrameworkCore.MySql   3.2.7

VS菜单中的 工具->NuGet包管理器 ->程序包管理器控制台 输入一下命令
```C#
Scaffold-DbContext "persist security info=True;data source=rm-bp18b613kv75bjlyl1o.mysql.rds.aliyuncs.com;port=3306;initial catalog=04010018;user id=student_19;password=student_19;character set=utf8;allow zero datetime=true;convert zero datetime=true;pooling=true;maximumpoolsize=3000" Pomelo.EntityFrameworkCore.MySql -OutputDir Models
```

会在你的解决方案中自动生成 Models目录和类文件