namespace BiruniEdu.WebUI.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            await _next(context);

            var elapsedTime = DateTime.UtcNow - startTime;
            Console.WriteLine($"İstek: {context.Request.Path}, Süre: {elapsedTime.TotalMilliseconds}ms");
        }
    }
}
