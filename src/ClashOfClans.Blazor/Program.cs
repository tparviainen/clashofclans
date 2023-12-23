using ClashOfClans.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddClashOfClans(options =>
{
    var clashOptions = new ClashOfClansOptionsV2();
    builder.Configuration.GetSection(ClashOfClansOptions.ClashOfClans).Bind(clashOptions);

    options.Tokens.AddRange(clashOptions.Tokens);
    options.MaxRequestsPerSecond = clashOptions.MaxRequestsPerSecond;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();

app.Run();
