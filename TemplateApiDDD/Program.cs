using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PetshopAPI.Repository;
using PetShopApi.Repository;
using Service;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddDbContext<Contextdb>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Contextdb>(options =>
 options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
 x => x.MigrationsAssembly("TemplateApiDDD")));

builder.Services.AddScoped<Contextdb, Contextdb>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IDonoRepository, DonoRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<ITipoAtendimentoRepository, TipoAtendimentoRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Template Api", Version = "v1" });
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

          app.UseCors("CorsPolicy");


            // app.UseMvc();

            // app.UseResponseCompression();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API - V1");
                x.RoutePrefix = string.Empty;
            });

app.UseAuthorization();

app.MapControllers();

app.Run();
