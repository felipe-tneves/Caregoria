using ApiCatalogo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ApiCatalogo.Extensions
{
    //classe estatica nao pode ser herdada e nem estaciada 
    public static class ApiExceptionMiddlewareExtensions
    {
        
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //definindo o middeware 
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //obtendo o status code 
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //definindo o tipo de retorno 
                    context.Response.ContentType = "application/json";

                    //obtendo informações e detalhes do erro
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }
                }); 
            });

        }
    }
}
