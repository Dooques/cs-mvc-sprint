using cs_mvc_sprint.Model.Services;
using cs_mvc_sprint.Model.Repositories;
using cs_mvc_sprint.Utils;
using cs_mvc_sprint.Models;
using System.Runtime.CompilerServices;

namespace cs_mvc_sprint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IAuthorsService, AuthorsService>();
            builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
