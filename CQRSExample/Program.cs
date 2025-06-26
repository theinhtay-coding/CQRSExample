var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(connectionString);
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
});

//builder.Services.AddOpenApi(); // Use minimal minimal OpenAPI
builder.Services.AddSwaggerGen(); // To enable Swagger generation

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi(); // Map the minimal OpenAPI
    app.UseSwagger(); // <-- To enable Swagger generation
    app.UseSwaggerUI(); // <-- To enable Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
