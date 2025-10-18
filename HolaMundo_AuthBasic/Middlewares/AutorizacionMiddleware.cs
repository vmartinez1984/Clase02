namespace HolaMundo_AuthBasic.Middlewares
{
    public class AutorizacionMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<AutorizacionMiddleware> _logger;

        public AutorizacionMiddleware(RequestDelegate request, ILogger<AutorizacionMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers;
            if (string.IsNullOrEmpty(header["apikey"]))
            {                
                context.Response.StatusCode = 401;
                //await context.Response.WriteAsync("No autorizado");
                return;
            }
            if (header["apikey"] != "8eaa2a56-b125-4685-a171-2ae3061b7d93")//GUID UUID
            {
                context.Response.StatusCode = 401;
                //await context.Response.WriteAsync("No autorizado");
                return;
            }
            await _request(context);
        }
    }
}
