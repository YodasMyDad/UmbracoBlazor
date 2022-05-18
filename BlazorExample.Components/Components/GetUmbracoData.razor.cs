using Microsoft.AspNetCore.Components;

namespace BlazorExample.Components.Components;

public partial class GetUmbracoData : ComponentBase
{
    [Inject] public HttpClient HttpClient { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
     
    private string Text { get; set; } = "Hello";
    private string WebsiteContent { get; set; }
    private string BaseUri { get; set; }
     
    protected override void OnInitialized()
    {
        BaseUri = NavigationManager.BaseUri;
        if (BaseUri.Contains("umbraco"))
        {
            BaseUri = BaseUri.Replace("umbraco/", string.Empty);
        }
        Text = "I'm a Blazor custom element, loading text from OnInitialized() running inside an Umbraco project, styled by Tailwind CSS";
    }

    private async Task GetWebsiteContent()
    {
        WebsiteContent = await HttpClient.GetStringAsync($"{BaseUri}Api/UtilitiesApi/GetWebsiteContent");
    }
}