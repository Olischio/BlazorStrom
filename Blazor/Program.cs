using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });






builder.Services.AddScoped(sp =>
{
    var t = new HttpClient();
    t.BaseAddress = new Uri("https://innafjord.azurewebsites.net/");

    // TODO: OBS Dette bør ikke sjekkes inn i github da det er en pålogging.
    t.DefaultRequestHeaders.Add("GroupId", "Vanndrikkerne");
    t.DefaultRequestHeaders.Add("GroupKey", "F9RQ/S90p0Gvt+DpGnZxxg==");

    return t;

    
});

await builder.Build().RunAsync();

