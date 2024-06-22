using DotNetTask.Server.Persistance;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Application.Commands;
using DotNetTask.Server.Application.Queries;
using DotNetTask.Server.Interfaces.Queries;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DotNetTaskServerContext>(options =>
    options.UseCosmos(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DotNetTaskServerContext' not found."), "TestDb"));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<CosmosClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var cosmosEndpoint = "https://localhost:8081/";
    var cosmosKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
    return new CosmosClient(cosmosEndpoint, cosmosKey);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.TryAddTransient<IFormProgramCommand, FormProgramCommand>();
builder.Services.TryAddTransient<IFormCommands, FormCommands>();
builder.Services.TryAddTransient<IFormQuestionsCommand, FormQuestionsCommand>();
builder.Services.TryAddTransient<IFormAnswersCommand, FormAnswersCommand>();

builder.Services.TryAddTransient<IFormQuery, FormQuery>();
builder.Services.TryAddTransient<IFormProgramQuery, FormProgramQuery>();
builder.Services.TryAddTransient<IFormQuestionsQuery, FormQuestionsQuery>();
builder.Services.TryAddTransient<IFormAnswersQuery, FormAnswersQuery>();

builder.Services.TryAddSingleton<CosmosSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    // Initialize database and containers
    var dbInitializer = app.Services.GetRequiredService<CosmosSetup>();
    await dbInitializer.InitializeAsync();
}

app.UseHttpsRedirection();


app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("Index.html");

app.Run();
