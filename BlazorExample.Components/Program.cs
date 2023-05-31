using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorExample.Components.Components;
using BlazorExample.Components.Components.Dashboards;
using BlazorExample.Components.Components.PropertyEditors;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.RootComponents.RegisterCustomElement<GetUmbracoData>("umbraco-data");
builder.RootComponents.RegisterCustomElement<LatestUmbracoTweets>("umbraco-tweets");
builder.RootComponents.RegisterCustomElement<SuggestionsExample>("umbraco-suggestions");
await builder.Build().RunAsync();