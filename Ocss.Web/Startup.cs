using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Ocss.Service.Models;
using Ocss.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocss.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//注册ControllerView，并添加一个认证过滤器
			services.AddControllersWithViews(option => { option.Filters.Add(typeof(AuthFilter)); });
			//开启Session
			services.AddSession();
			//添加一个单例的HttpContext上下文访问器
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			//开启Cookie
			app.UseCookiePolicy();
			//开启Session
			app.UseSession();
			app.UseEndpoints(endpoints =>
			{
				// 第一个路由
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=ShowLogin}/{id?}");

			});
		}
	}
}
