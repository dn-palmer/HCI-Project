using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BitWise.Data;
using BitWise.Areas.Identity.Data;
using BitWise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAchievementsRepo, AchievementsRepo>();
string? connection;

if (builder.Environment.IsDevelopment())
{
    connection = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
    connection = Environment.GetEnvironmentVariable("connectionString");
    if (connection == null)
    {
        throw new Exception("Connection string Env variable couldn't be found");
    }
}
builder.Services.AddDbContext<BitWiseContext>(options =>
    options.UseNpgsql(connection));builder.Services.AddDefaultIdentity<BitWiseUser>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        })
    .AddEntityFrameworkStores<BitWiseContext>();





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
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();
