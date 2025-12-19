using EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//添加跨域
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWithCredentials", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // 明确指定前端地址
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // 允许凭据,signalr需要
    });
});

//数据库
builder.Services.AddDbContext<BlogDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BlogDbContext");
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mysqlOptions =>
        {
            mysqlOptions.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName);
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowWithCredentials"); // 使用跨域策略


app.MapControllers();       // 映射 API 
app.Run();