namespace HolaMundo_Middleware.Middlewares
{
    public class Test02Middleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<Test02Middleware> _logger;

        public Test02Middleware(RequestDelegate request, ILogger<Test02Middleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Inicio del Test02Middleware");
            _request(context);
            _logger.LogInformation("Fin del Test02Middleware");
        }
    }
}
