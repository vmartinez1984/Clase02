using Newtonsoft.Json;
using System.Text;

namespace HolaMundo_Watchdog.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate request, ILogger<ExceptionMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await AnalizeRequest(context);
                await  _request(context);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        /// <summary>
        /// Aqui extraemos los datos
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task AnalizeRequest(HttpContext context)
        {
            using (StreamReader stream = new StreamReader(context.Request.Body))
            {
                string path;
                string queryString;
                string header;
                string body;
                string method;


                path = context.Request.Path;
                queryString = context.Request.QueryString.Value;
                header = JsonConvert.SerializeObject(context.Request.Headers).Replace("[", string.Empty).Replace("]", string.Empty);
                method = context.Request.Method;
                body = await stream.ReadToEndAsync();


                byte[] bytes = Encoding.UTF8.GetBytes(body);
                context.Request.Body = new MemoryStream(bytes);
            }
        }
    }
}
