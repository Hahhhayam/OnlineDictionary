using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineDictionary.API.Models;
using OnlineDictionary.API.Repositories;
using OnlineDictionary.API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddDbContext<OnlineDictionaryContext>();
builder.Services.AddTransient<ILangugageRepository, LanguageRepository>();
builder.Services.AddTransient<ILangugageService, LanguageSevice>();
builder.Services.AddTransient<IWordRepository, WordRepository>();
builder.Services.AddTransient<IWordService, WordService>();
builder.Services.AddTransient<ITranslateRepository, TranslateRepository>();
builder.Services.AddTransient<ITranslateService, TranslateService>();
builder.Services.AddTransient<IDictRepository, DictRepository>();
builder.Services.AddTransient<IDictService, DictService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => //CookieAuthenticationOptions
{
    options.LoginPath = new PathString("/Auth/Login");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
