using SistemaGestionDeCalidad.IOC;

var builder = WebApplication.CreateBuilder(args);

// Agrega la configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Si necesitas que se envíen credenciales/cookies
    });
});

// **Aquí agregas la configuración de sesión**
builder.Services.AddDistributedMemoryCache();  // Agregar un caché en memoria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true;  // Asegura que la cookie no sea accesible desde JavaScript
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InyectarDependencias(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura CORS antes de mapear los controladores
app.UseCors("AllowAngularClient");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();  // Esta línea debe ir antes de `app.UseAuthorization()`

app.UseAuthorization();

app.MapControllers();

app.Run();
