using MyBlazorHybridApp.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Definisikan nama policy CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// --- 1. TAMBAHKAN SERVICE CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Izinkan permintaan dari alamat frontend Web Anda
                          // PASTIKAN NOMOR PORT INI (7206) SESUAI DENGAN PORT FRONTEND ANDA
                          policy.WithOrigins("https://localhost:7206")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source = pizza.db");

//Add DI
builder.Services.AddScoped<ISpecials, SpecialsData>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
// Menambahkan dan mengkonfigurasi Swagger
builder.Services.AddEndpointsApiExplorer();
object value = builder.Services.AddSwaggerGen(options =>
{
    // Mendefinisikan dokumen OpenAPI/Swagger
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Blazing Pizza API",
        Version = "v1"
    });
});

var app = builder.Build();
//builder.Services.AddScoped(sp => new HttpClient());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Menggunakan UI Swagger dengan endpoint yang spesifik
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazing Pizza API v1");
    });
}

app.UseHttpsRedirection();

// --- 2. GUNAKAN MIDDLEWARE CORS ---
// PENTING: Letakkan UseCors di sini. Setelah UseHttpsRedirection, sebelum UseAuthorization.
app.UseCors(MyAllowSpecificOrigins);



app.UseAuthorization();

app.MapControllers();

//var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
//using (var scope = scopeFactory.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
//    db.Database.EnsureCreated();
//    SeedData.Initialize(db);
//}
app.Run();
