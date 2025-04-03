namespace BiruniEdu.WebUI.Middlewares
{
    public class IpLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public IpLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress;

            Console.WriteLine($"Ip: {ip}");

            await _next.Invoke(context);

            Console.WriteLine("Response");
        }
    }
}
