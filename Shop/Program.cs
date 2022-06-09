using Shop.Data.interfaces;
using Shop.Data.mocks;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
// связь где реализуется интерфейс (в моке)
builder.Services.AddTransient<IAllCars,MockCars >();
builder.Services.AddTransient<ICarsCategory, MockCategory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
   
}


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