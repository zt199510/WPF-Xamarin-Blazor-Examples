﻿/*
*
* 文件名    ：AutofacLocator                             
* 程序说明  : Autofac实现
* 更新时间  : 2020-05-21 16：05
* 联系作者  : QQ:779149549 
* 开发者群  : QQ群:874752819
* 邮件联系  : zhouhaogg789@outlook.com
* 视频教程  : https://space.bilibili.com/32497462
* 博客地址  : https://www.cnblogs.com/zh7791/
* 项目地址  : https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples
* 项目说明  : 以上所有代码均属开源免费使用,禁止个人行为出售本项目源代码
*/

namespace Consumption.PC.Core
{
    using Autofac;
    using Consumption.Core.Interfaces;
    using Consumption.PC.ViewCenter;
    using Consumption.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    /// <summary>
    /// Autofac实现
    /// </summary>
    public class AutofacLocator : IAutoFacLocator
    {
        Autofac.IContainer container;

        public TInterface Get<TInterface>(string typeName)
        {
            return container.ResolveNamed<TInterface>(typeName);
        }

        public TInterface Get<TInterface>()
        {
            return container.Resolve<TInterface>();
        }

        public void Register()
        {
            if (container != null) return;
            var Container = new ContainerBuilder();
            Container.RegisterType(typeof(LoginCenter)).Named("LoginCenter", typeof(IModuleDialog));
            Container.RegisterType(typeof(MainCenter)).Named("MainCenter", typeof(IModuleDialog));
            container = Container.Build();
        }
    }
}
