using Invetker;
using Invetker.Controllers;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InvetkerContext>();

builder.Services.AddIdentityApiEndpoints<UserModel>(opts =>
{
  opts.SignIn.RequireConfirmedEmail = false;
  opts.SignIn.RequireConfirmedAccount = false;
  opts.SignIn.RequireConfirmedPhoneNumber = false;
  opts.Password.RequireDigit = false;
  opts.Password.RequireLowercase = false;
  opts.Password.RequireUppercase = false;
  opts.Password.RequireNonAlphanumeric = false;
  opts.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<InvetkerContext>();

builder.Services.ConfigureApplicationCookie(opts => {
  opts.LoginPath = "/Home";
});

builder.Services.AddAuthentication(opts => {
  opts.DefaultScheme = IdentityConstants.ApplicationScheme;
  opts.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(opt => // UseSwaggerUI is called only in Development.
  {
    // options.SwaggerEndpoint("/swagger-ui/v1/swagger.json", "v1");
    opt.RoutePrefix = "swagger";
  });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapFallbackToFile("index.html");

// https://www.telerik.com/blogs/new-net-8-aspnet-core-identity-how-implement
// app.MapGroup("/user").MapIdentityApi<UserModel>();

app.Run();