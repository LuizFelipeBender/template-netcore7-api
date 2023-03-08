using Data;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<Contextdb, Contextdb>();
builder.Services.AddTransient<TemplateService, TemplateService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Contextdb>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();


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
