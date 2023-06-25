using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();



builder.Services.AddScoped(sp =>
{
    var t = new HttpClient();
    t.BaseAddress = new Uri("https://innafjord.azurewebsites.net/");

    // TODO: OBS Dette bør ikke sjekkes inn i github da det er en pålogging, men dette er et api for ett fiktift vannverk så det utøver ingen skade.
    t.DefaultRequestHeaders.Add("GroupId", "Vanndrikkerne");
    t.DefaultRequestHeaders.Add("GroupKey", "F9RQ/S90p0Gvt+DpGnZxxg==");

    return t;

    
});

await builder.Build().RunAsync();

