using EF;
using Microsoft.EntityFrameworkCore;
using WebService.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//添加跨域
builder.Services.AddCors(options =>
{
    string _frontAddress = builder.Configuration.GetValue<string>("FrontAddress");
    if (_frontAddress == null)
    {
        return;
    }
    options.AddPolicy("AllowWithCredentials", policy =>
    {
        policy.WithOrigins(_frontAddress) // 明确指定前端地址
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // 允许凭据,signalr需要
    });
});

//数据库上下文配置
// 数据库配置 - 修正这里！
//var connectionString = builder.Configuration.GetConnectionString("BlogDbContext");
//builder.Services.AddDbContext<BlogDbContext>(options =>
//{
//    options.UseMySql(
//        connectionString,
//        new MySqlServerVersion(new Version(8, 0, 44)),
//        mysqlOptions =>
//        {
//            // 指定迁移程序集为 EF（BlogDbContext 所在的程序集）
//            mysqlOptions.MigrationsAssembly("EF");
//        });
//});
//数据库上下文配置,放到了其他的文件中去了
builder.Services.ConfigureMySqlConetxt(builder.Configuration); //上下文
builder.Services.ConfigureServiceScope();
//builder.Services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowWithCredentials"); // 使用跨域策略


app.MapControllers();       // 映射 API 
app.Run();