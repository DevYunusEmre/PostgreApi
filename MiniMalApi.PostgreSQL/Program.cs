using Business.Entities;
using Business.Services;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
string connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("PostgreSqlConnection"));
})
.UseLightweightSessions(); // Call UseLightweightSessions after configuring Marten

// Register DocumentStore with Scoped lifetime
builder.Services.AddScoped<DocumentStore>();

// UserService'in DI'a kaydý
builder.Services.AddScoped<UserService>();

// Kestrel yapýlandýrmasý (Portu 8080 olarak ayarlýyoruz)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);  // Kestrel'in 8080 portunda dinlemesini saðlýyoruz
});
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/user/{id}", (int id, UserService userService) =>
{
    return userService.GetUser(id);
});

app.MapGet("/GetAllUsers", (UserService userService) =>
{
    return userService.GetAllUsers();
});

app.MapPost("/addUser", (User user, UserService userService) =>
{
    return userService.AddUser(user);
});

app.MapDelete("/deleteUser/{userId}", (int userId, UserService userService) =>
{
    return userService.DeleteUserById(userId);
});

app.Run();
