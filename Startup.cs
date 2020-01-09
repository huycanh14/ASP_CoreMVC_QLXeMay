using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebQLXeMay.Middlewares;
using WebQLXeMay.Repository;
using WebQLXeMay.Services;

namespace WebQLXeMay
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
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStr")));
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddMvc();
            services.AddTransient<IAdmin, AdminRepository>();
            services.AddTransient<IHDNhap, HDNhapRepository>();
            services.AddTransient<IHDXuat, HDXuatRepository>();
            services.AddTransient<IKhachHang, KhachHangRepository>();
            services.AddTransient<INCC, NCCRepository>();
            services.AddTransient<INhanVien, NhanVienRepository>();
            services.AddTransient<IXeMay, XeMayRepository>();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseBrowserLink();
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseStatusCodePagesWithRedirects("/Home/Error");
            //}

            app.UseSession();
            app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware404();
            //app.UseMiddleware<Middleware404>();
            app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Home/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
