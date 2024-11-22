using Microsoft.EntityFrameworkCore;
using BSCHub.Application.Contracts.Persistence;
using BSCHub.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SocialWorkDbConnection") ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<SocialWorkDbContext>(options =>
    options.UseNpgsql(connectionString)); ;


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IConsultantRepository, ConsultantRepository>();
builder.Services.AddScoped<IDateRepository, DateRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=List}/{id?}");
app.UseExceptionHandler("/Error");

app.UseStatusCodePagesWithReExecute("/Error/{0}");


app.Run();
