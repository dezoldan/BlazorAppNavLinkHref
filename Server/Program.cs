using BlazorApp1.Server.Data;
using BlazorApp1.Server.ServiceServerAluno;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Habilita sqllocal
builder.Services.AddDbContext<DataContext>
        (
        options => {
            options
                .UseSqlServer("Server=.\\SQLExpress;DataBase=Alunos1;trusted_connection=true;TrustServerCertificate=true");
        });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IServiceAluno, ServiceAluno>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();