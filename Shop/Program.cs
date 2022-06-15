using Shop.Data.interfaces;
using Shop.Data.Repository;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

var builder = WebApplication.CreateBuilder(args);
// БД
// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCar.GetCar(sp));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddMemoryCache();
builder.Services.AddSession();

// связь где реализуется интерфейс (в моке)
builder.Services.AddTransient<IAllCars,CarRepository >();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
    app.UseHsts();
   
    //using (var scope = app.ApplicationServices.CreateScope())
    //{
    //    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    //    DBObjects.Initial(content);
    //}
   
}


app.UseSession();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

app.Run();