using EmbeddingClassificationAPI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your custom services
builder.Services.AddSingleton<EmbeddingService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new EmbeddingService(configuration["OpenAI:ApiKey"]);
});
builder.Services.AddSingleton<CardService>();

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
app.UseAuthorization();
app.MapControllers();

app.Run();
