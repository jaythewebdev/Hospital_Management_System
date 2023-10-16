//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;

////[assembly: FunctionsStartup(typeof(AzureFunctionAppSample.Startup))]


//namespace AzureFunctionAppSample
//{
//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            // Add Swagger documentation generation
//            // Add Swagger UI
//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
//            });
//        }
//    }
//}
