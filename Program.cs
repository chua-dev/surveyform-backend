using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SurveyForm;
using SurveyForm.Data;
using SurveyForm.Interfaces;
using SurveyForm.Repository;


// CORS Policy
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:3000",
                                              "http://localhost:3000")
                          .WithHeaders(HeaderNames.ContentType, "application/json");
                      });
});*/


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();

// Auto dependancy Injection
builder.Services.AddScoped<ISurveyQuestionsRepository, SurveyQuestionsRepository>();
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();
builder.Services.AddScoped<ISurveyAnswerRepository, SurveyAnswerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Data Context configuration to use dependancy injection
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
