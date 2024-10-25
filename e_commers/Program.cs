using demo.APIS.CityService;
using demo.interfaces;

var builder = WebApplication.CreateBuilder(args);

/*DI : Dependency Injection Of CityService*/
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ICityService, CityService>();

var app = builder.Build();

Logger.Instance.Log("Application started");

app.UseRouting();
app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

Logger.Instance.Log("Application End");

app.Run();
