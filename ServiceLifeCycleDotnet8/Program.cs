using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLifeCycleWebApp.Models.Enums;
using ServiceLifeCycleWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKeyedTransient<IStudentService, JuniorService>(nameof(StudentType.Junior));
builder.Services.AddKeyedTransient<IStudentService, SeniorService>(nameof(StudentType.Senior));
builder.Services.AddKeyedTransient<IStudentService, SpecialStudentService>(nameof(StudentType.Special));
builder.Services.AddKeyedTransient<IStudentService, SophomoreService>(nameof(StudentType.Sophomore));

builder.Services.AddTransient<IStudentService, JuniorService>();
builder.Services.AddTransient<IStudentService, SeniorService>();
builder.Services.AddTransient<IStudentService, SophomoreService>();



builder.Services.AddControllersWithViews();




builder.Services.AddEndpointsApiExplorer();
 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();