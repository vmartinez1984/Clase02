namespace HolaMundo_Middleware.Middlewares
{
    public class Test01Middleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<Test01Middleware> _logger;

        public Test01Middleware(RequestDelegate request, ILogger<Test01Middleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Inicio del Test01Middleware");
            _request(context);
            _logger.LogInformation("Fin del Test01Middleware");
        }
    }
}
