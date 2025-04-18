// File: ApiBackend/Program.cs

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None; // 🔑
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // 🔑
});

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowFrontend", policy =>
//     {
//         policy.WithOrigins("https://localhost:7041", "http://localhost:5166") //frontend origins
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//             .AllowCredentials(); // 🔑
//     });
// });

//Cors policy

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // 🔑
    });
});


var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseCors("AllowFrontend");
app.UseCors();
app.UseSession();
app.UseAuthorization();

app.MapControllers();

app.Run();