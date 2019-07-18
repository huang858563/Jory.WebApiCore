using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace Jory.WebApiCore
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0.0",
                    Title = "Jory WebAPI",
                    Description = "接口文档",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Jory",
                        Email = "jory@mail.com",
                        Url = "http://www.cnblogs.com/Jory"
                    }
                });
                //添加读取注释服务
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
                var modelXmlFile = "Jory.Model.xml";
                var modelXmlPath = Path.Combine(AppContext.BaseDirectory, modelXmlFile);
                c.IncludeXmlComments(modelXmlPath, true);

                //手动高亮
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                // var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                // c.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                // c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                // {
                //     Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                //     Name = "Authorization",//jwt默认的参数名称
                //     In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                //     Type = "apiKey"
                // });
            });


            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi V1.0");
            });
            #endregion
        }
    }
}
