using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentControl.Data;
using StudentControl.Data.Repositories;
using StudentControl.Data.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.(gitTest)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IStudentRepository,StudentRepository>();
builder.Services.AddTransient<IGrupRepository,GroupRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Group}/{action=Groups}/{id?}");
app.MapRazorPages();

app.Run();
