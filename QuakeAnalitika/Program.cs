using FluentValidation;
using QuakeAnalitika.Model.MappingProfiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using QuakeAnalitika.Model;
using QuakeAnalitika.Model.Open.Validation;
using QuakeAnalitika.Services;
using QuakeAnalitika.Services.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/login");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.AccessDeniedPath = "/Error/AccessDenied";
    });

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IReportRepository, ReportRepository>();

builder.Services.AddAutoMapper(bld =>
{
    bld.AddProfile(new QuakeAnalitikaInternalProfile());
});

builder.Services.AddDbContext<QuakeAnalitikaContext>();
using var cont = new QuakeAnalitikaContext();
cont.Database.EnsureCreated();

builder.Services.AddValidatorsFromAssemblyContaining<CredentialsValidator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
