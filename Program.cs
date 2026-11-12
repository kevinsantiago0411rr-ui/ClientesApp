using Microsoft.EntityFrameworkCore;
using ClientesApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar el contexto de la base de datos (ApplicationDbContext) usando Pomelo con MySQL
// Esto lee la cadena de conexión configurada en appsettings.json y detecta automáticamente la versión de MySQL en MAMP
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Agregar los servicios para los controladores y las vistas al contenedor de dependencias (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP (manejo de errores y seguridad)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es de 30 días. 
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS
app.UseStaticFiles();     // Habilita el uso de archivos estáticos 

app.UseRouting();         // Habilita el sistema de enrutamiento

app.UseAuthorization();   // Habilita la autorización de usuarios

// Configurar la ruta predeterminada para los controladores (Controlador / Acción / Id opcional)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Ejecuta la aplicación web