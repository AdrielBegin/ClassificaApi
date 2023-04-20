using ClassificaApi.Model;
using ClassificaApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Conexão
var connectionString = builder.Configuration.GetConnectionString("Jornal");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ClassificaContext>(options =>   options.UseSqlServer(connectionString));

builder.Services.AddScoped<IClassificadosRepository, ClassificadosRepository>();
// Controller
builder.Services.AddControllers().AddJsonOptions(options => { 
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy= null;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors(builder =>
builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
.WithHeaders("Authorization", "Content-Type"));

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();