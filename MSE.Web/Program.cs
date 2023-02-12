using MSE.Business.Extensions;
using MSE.DataAccess.Extensions;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson();

#region define dependency injection parts

builder.Services.LoadBusinessLayerExtension();
builder.Services.LoadDataAccessLayerExtension(builder.Configuration);

//Logging with Serilog
Logger log = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt")
            .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("cnnstr"),
            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions()
            {
                TableName = "Logs",
                AutoCreateSqlTable = true
            })
            .MinimumLevel.Information()
            .CreateLogger();

builder.Host.UseSerilog(log);

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProductionLine}/{action=Index}/{id?}");

app.Run();
