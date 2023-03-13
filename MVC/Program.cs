namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline. //middlewares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #region Custom Middlewares
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("1- Middleware 1 \n");
            //    await next.Invoke();
            //});

            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2- Middleware 2\n");
            //    await next.Invoke();
            //});
            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3- Middleware Terminate\n");
            //});
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("Unreachable middleware");
            //    await next.Invoke();
            //});
            #endregion
            app.Run();
        }
    }
}