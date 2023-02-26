using AutoMapper;
using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Services;
using web_api.Profiles;
using web_api.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<PogwartsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<CharacterService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<WeaponService>();
builder.Services.AddScoped<EnemyService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new CharacterProfile(provider.GetService<PogwartsContext>()));
    cfg.AddProfile(new UserProfile());
    cfg.AddProfile(new WeaponProfile());
    cfg.AddProfile(new ArmorProfile());
}).CreateMapper());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
    corsbuilder =>
    {
        corsbuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
    });
});






var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PogwartsContext>();

    if (!context.Weapon.Any())
    {
        var weaponsJson = File.ReadAllText("weapons.json");
        var weapons = JsonConvert.DeserializeObject<List<Weapon>>(weaponsJson);

        context.Weapon.AddRange(weapons);
        context.SaveChanges();
    }
    if (!context.Enemy.Any())
    {
        var enemyJson = File.ReadAllText("enemies.json");
        var enemies = JsonConvert.DeserializeObject<List<Enemy>>(enemyJson);

        context.Enemy.AddRange(enemies);
        context.SaveChanges();
    }
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();