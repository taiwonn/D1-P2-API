using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(@"
╔═══════════════════════════════════════════╗
║            API LAUNCH IN PROGRESS         ║
╚═══════════════════════════════════════════╝");
Console.ResetColor();

var builder = WebApplication.CreateBuilder(args);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(@"
📦 Services Configuration:
└── 🏗️  Builder created");
Console.ResetColor();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddControllers();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("    └── 🎮 Controllers added");
Console.ResetColor();

var app = builder.Build();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n🔧 Application Configuration:");
Console.WriteLine("└── 🏭 Application built");
Console.ResetColor();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("    └── 🐛 Development mode enabled");
    Console.ResetColor();
}

app.UseHttpsRedirection();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("    └── 🔒 HTTPS redirection enabled");
Console.ResetColor();

app.UseRouting();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("    └── 🛣️  Routes configured");
Console.ResetColor();

app.MapControllers();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("    └── 🎯 Endpoints mapped");
Console.ResetColor();

// Test database connection
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.CanConnect(); // Vérifie la connexion à la base de données
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("    └── ✅ Database connection successful");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    └── ❌ Database connection failed: " + ex.Message);
    }
    Console.ResetColor();
}

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(@"
╔═══════════════════════════════════════════╗
║         API STARTED SUCCESSFULLY          ║
╚═══════════════════════════════════════════╝");
Console.ResetColor();

app.Run();
