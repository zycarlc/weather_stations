using find_weather_station.db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  allowing all api request in cors policy !!config the policy before implement in production!!
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy  =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add the WeatherContext
builder.Services.AddEntityFrameworkNpgsql()
        .AddDbContext<WeatherContext>(options => 
        options.UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//allow my map to access
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
