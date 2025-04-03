namespace BiruniEdu.WebUI.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggerMiddleware>();
        }

        public static IApplicationBuilder UseIpLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpLoggerMiddleware>();
        }

        public static IApplicationBuilder UseIpFilter(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpFilterMiddleware>();
        }
    }
}
