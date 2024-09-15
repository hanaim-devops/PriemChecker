using PriemCheckerLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PriemCheckContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=PriemCheckDb;User=sa;Password=Your_password123;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/isPriem", (PriemChecker priemgetalChecker, int getal) =>
    {
        return priemgetalChecker.IsPriemgetal(getal);
    })
    .WithName("IsPriem")
    .WithOpenApi();


app.Run();