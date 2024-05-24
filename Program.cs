using JobSearchPortal.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using JobSearchPortal.Data;
using JobSearchPortal.Models;
using JobSearchPortal.Services;
using JobSearchPortal.Interfaces;
using JobSearchPortal.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the ApplicationDbContext with a connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("JobSearchPortalDatabase"),
                     new MySqlServerVersion(new Version(8, 0, 33))));

// Register the JobSearchService and configure HttpClient
builder.Services.AddHttpClient<JobSearchService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["USAJobsAPI:BaseURL"]);
})
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    });

// Register the configuration for JobSearchService
builder.Services.AddScoped<IJobSearchServices, JobSearchService>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var config = provider.GetRequiredService<IConfiguration>();
    var apiKey = config["USAJobsAPI:APIKey"];
    var baseURL = config["USAJobsAPI:BaseURL"];
    return new JobSearchService(httpClient, apiKey, baseURL);
});

// Register the JobSearchPortalRepository
builder.Services.AddScoped<IJobSearchPortalRepository, JobSearchPortalRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
