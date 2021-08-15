using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatMvc.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;


        public ErrorHandlerMiddleware(RequestDelegate next , ILoggerFactory logger)
        {
            _next = next;
            _loggerFactory = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<ErrorHandlerMiddleware>();

            try
            {
                await _next(context);

            }catch(Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError($"Something went wrong: {ex.Message}");
                response.Redirect("/Error/Index");
            }
        }
    }
}
