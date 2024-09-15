using PriemCheckerLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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