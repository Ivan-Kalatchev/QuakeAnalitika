using FluentValidation;
using MakeupTok.Model;
using MakeupTok.Model.MappingProfiles;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddTransient<IMakeupRepository, MakeupRepository>();

builder.Services.AddAutoMapper(bld =>
{
    bld.AddProfile(new MakeupTokInternalProfile());
});

builder.Services.AddDbContext<MakeupTokContext>();

builder.Services.AddValidatorsFromAssemblyContaining<CredentialsValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MakeupTok.Model.Validation.UserValidator>();

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
