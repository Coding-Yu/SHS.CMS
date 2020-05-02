# SHS.CMS

#### 介绍
一个基于.net Core的CMS网站，正在完善中。
1. 认证服务器地址：http://localhost:5000
2. API服务器地址：http://localhost:5001
3. 后台地址:http://localhost:9528
4. Dome地址:http://www.shscms.cn

#### 软件架构
后端项目使用.Net Core 3.1 DDD领域驱动模式进行开发，前端使用Vue-element-admin


#### 安装教程
windows安装教程:
基于IIS 部署
1. 前期准备
	1.1 在服务器上安装相应的.net core 3.1.3 SDK
	1.2 安装配置nodejs环境
	1.3 安装配置vue
	1.4 进行IIS urlrewrite ARR（Application Request Routing）插件，进行端口转发。
2. 具体部署流程请参考https://www.cnblogs.com/cjdonet/p/12816751.html
#### 使用说明

1. 运行SHS.Authorization项目用来用户授权操作
2. 运行API
3. 运行admin后台管理页面

#### 参与贡献
