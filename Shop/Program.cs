using Shop.Data.interfaces;
using Shop.Data.Repository;
using Shop.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// ��
// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));


// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

// ����� ��� ����������� ��������� (� ����)
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