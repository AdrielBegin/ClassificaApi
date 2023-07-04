using ClassificaApi;
using ClassificaApi.Model;
using ClassificaApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});

//inicio: token

var key = Encoding.ASCII.GetBytes(Settings.Secrect);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//fim: token

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Conexão
var connectionString = builder.Configuration.GetConnectionString("Jornal");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ClassificaContext>(options =>
    options.UseSqlServer(connectionString));

// Injeção de dependência
builder.Services.AddScoped<IClassificadosRepository, ClassificadosRepository>();
builder.Services.AddScoped<IUsuariosRepostitory, UsuariosRepostitory>();

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
           .SetIsOriginAllowed(_ => true)
           .WithHeaders("Authorization", "Content-Type")
);

app.UseHttpMethodOverride();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();