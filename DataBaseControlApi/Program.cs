using DataBaseControlApi.Core;
using DataBaseControlApi.Infrastructure;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>((s) => new SqlConnection(builder.Configuration.GetConnectionString("MainDataBase")));

builder.Services.AddScoped<BookRepository>();
builder.Services.AddScoped<UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
