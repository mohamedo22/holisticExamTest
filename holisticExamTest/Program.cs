
using holisticExamTest.appcontext;
using holisticExamTest.IRepos;
using holisticExamTest.Repos;
using Microsoft.EntityFrameworkCore;

namespace holisticExamTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var firstConnection = builder.Configuration.GetConnectionString("firstConnection");
            builder.Services.AddDbContext<appdbcontext>(options=> options.UseSqlServer(firstConnection));
            builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
            builder.Services.AddScoped<IAccountsRepo, AccountsRepo>();
            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
