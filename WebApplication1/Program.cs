using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//It's working like pipeline, we get request from browset, then we response(all the app.*)
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
//MODEL - represents the shape of the data
//VIEW -  represents the user interface
//CONTROLLER - handles the user request and acts as an interface between MODEL and VIEW
//If user click on our APP, CONTROLLER get the request, it will use all the data from MODEL(get data) that he needs to display inside the VIEW
// once VIEW is rendered, it will pass all of that to the CONTROLLER, then the CONTROLLER will pass the responce, which will be send back and the user
// will be finally available to see the page.
app.MapControllerRoute(
    name: "default", //if nothing is provided(in the URL) it should go the home controller, index action, id is optional
                     //it is placed in Views/Home/Index.cshtml
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();