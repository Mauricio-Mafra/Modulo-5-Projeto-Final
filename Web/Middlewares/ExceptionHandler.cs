﻿using Domain.Exceptions;

namespace Web.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) {
                if(typeof(ICustomException).IsAssignableFrom(ex.GetType()))
                {
                    var exInterface = ex as ICustomException;
                    context.Response.StatusCode = exInterface!.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(exInterface.GetResponse());
                }
            }
        }
    }
}
