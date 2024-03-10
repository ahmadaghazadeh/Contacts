using Framework.Domain;
using System.Net;
using System.Text.Json;
using API.Model;

namespace Mc2.CrudTest.Presentation.Server.Configuration
{
	public class CustomExceptionHandlerMiddleware : IMiddleware
	{
		private readonly ILogger<CustomExceptionHandlerMiddleware> logger;
		private readonly IHostEnvironment env;

		public CustomExceptionHandlerMiddleware(
			ILogger<CustomExceptionHandlerMiddleware> logger)
		{
			this.logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			var apiException = new APIException();
			var jso = new JsonSerializerOptions
			{
				Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};
			try
			{
				await next(context);
			}
			catch (DomainException exception)
			{
				apiException.Message = exception.Message;
				logger.LogError(exception, $"ِ[Domain Exception] [{apiException.Message}]");
				await WriteToResponseAsync();
			}
			catch (Exception exception)
			{
				apiException.Message = exception.Message;
				logger.LogError(exception, $"[Application Exception] [{exception.Message}]");
				await WriteToResponseAsync();
			}

			async Task WriteToResponseAsync()
			{
				    var result = JsonSerializer.Serialize(apiException, jso);
				    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
					context.Response.ContentType = "application/json";
					await context.Response.WriteAsync(result);
			}
		}
	}
}
