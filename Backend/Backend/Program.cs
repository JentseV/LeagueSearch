using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();



builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var key = Encoding.ASCII.GetBytes("cSeyq0I4QBbz4EY44VCoBwXZ0gFXLZtc_aSmd5WsAMl3ivVt2gSUJXQznPinYsS5");

var jwksUrl = "https://dev-qoa8c8pxfm0stq6b.us.auth0.com/.well-known/jwks.json";
var jwksHandler = new JwtSecurityTokenHandler();
var jwksString = await new HttpClient().GetStringAsync(jwksUrl);
var jwks = JsonConvert.DeserializeObject<JsonWebKeySet>(jwksString);

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKeys = jwks.Keys
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://dev-qoa8c8pxfm0stq6b.us.auth0.com/",
        ValidAudience = "https://leaguesearch/myapi",
        IssuerSigningKey = tokenValidationParameters.IssuerSigningKey // Replace with your Auth0 secret key
    };
});

builder.Services.AddDbContext<SummonerContext>(opt =>
    opt.UseInMemoryDatabase("Summoners"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});


builder.Services.AddAuthorization(options =>
{
    // Define a policy named "RequireLoggedIn"
    options.AddPolicy("RequireLoggedIn", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
