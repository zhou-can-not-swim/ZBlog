using EF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using WebService.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//从配置文中读取Serilog配置
builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)//允许 Serilog 从 DI 容器中解析服务（比如 ILogger<T>）。
    .Enrich.FromLogContext());//允许在日志中添加额外的上下文信息，比如请求ID、用户ID等。

#region 身份验证
// 配置认证服务
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    // 可选：自定义事件处理
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"认证失败: {context.Exception.Message}");
            return Task.CompletedTask;
        }
    };
});

// 配置授权策略
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("Over18", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == ClaimTypes.DateOfBirth &&
                DateTime.Parse(c.Value).AddYears(18) <= DateTime.Today)));
});
#endregion
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

//数据库
// 数据库配置 - 修正这里！
var connectionString = builder.Configuration.GetConnectionString("BlogDbContext");
builder.Services.AddDbContext<BlogDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 44)),
        mysqlOptions =>
        {
            // 指定迁移程序集为 EF（BlogDbContext 所在的程序集）
            mysqlOptions.MigrationsAssembly("EF");
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

// AutoMapper 配置
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

#region 启用认证和授权中间件（顺序很重要！）
// 启用认证和授权中间件（顺序很重要！）
app.UseAuthentication();
app.UseAuthorization();
#endregion
app.Run();