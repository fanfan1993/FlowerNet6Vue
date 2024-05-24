using yanfanFlower.Service.Config;
using AutoMapper;
using yanfanFlower.Service.Flower;
using yanfanFlower.Service;
namespace yanfanNet6WebAPi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",opt=> opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ע��AutoMappeper
            //builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

            // ע��server
            builder.Services.AddTransient<IFlowerService, FlowerService>();
            builder.Services.AddTransient<IUserService, UserService>();

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
            // ����
            app.UseCors("CorsPolicy");

            app.Run();
        }
    }
}
