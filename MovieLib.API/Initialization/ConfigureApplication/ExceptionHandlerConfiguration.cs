using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using MovieLib.BL.Common.Extensions;
using MovieLib.BL.Common.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MovieLib.API.Initialization.ConfigureApplication
{
    public static class ExceptionHandlerConfiguration
    {
        /// <summary>
        /// Применение настройки ExceptionHandler с использованием типизированного ответа в случае <see cref="Exception"/>.
        /// Ответ отдается в виде Json модели <see cref="ErrorListResponse"/>
        /// </summary>
        public static IApplicationBuilder UseExceptionHandlerWithJsonResponse(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    // Use exceptionHandlerPathFeature to process the exception (for example, 
                    // logging), but do NOT expose sensitive error information directly to 
                    // the client.
                    var e = exceptionHandlerPathFeature?.Error;

                    var errorList = e?.GetErrorListResponseFromException();

                    if (errorList != null)
                    {
                        var settings = new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        };
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorList, settings));
                    }
                });
            });

            return app;
        }
    }
}
