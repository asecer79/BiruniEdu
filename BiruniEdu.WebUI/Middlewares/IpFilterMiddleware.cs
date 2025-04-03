namespace BiruniEdu.WebUI.Middlewares
{
    public class IpFilterMiddleware
    {
        private readonly RequestDelegate _next;

        public IpFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString();
            var whiteIps = new[] { "192.168.1.100", "10.0.0.5","127.0.0.1"};

            if (!whiteIps.Contains(ip))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Bu IP adresinden erişim engellendi.");
                return;
            }

            await _next(context);



        }
    }
}
