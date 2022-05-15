using BlazorExample.Shared.Comparers;
using BlazorExample.Shared.Extensions;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Tweetinvi.Models.V2;

namespace BlazorExample.Components.Components.Dashboards;

public partial class LatestUmbracoTweets : ComponentBase
{
    [Inject] public HttpClient HttpClient { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    private string? BaseUri { get; set; }
    private IEnumerable<TweetV2> Tweets { get; set; }

    private bool Loading { get; set; }
    
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Tweets = new List<TweetV2>();
        BaseUri = NavigationManager.BaseUri;
        if (BaseUri.Contains("umbraco"))
        {
            BaseUri = BaseUri.Replace("umbraco/", string.Empty);
        }
        
        var timer = new Timer(_ =>
        {

            InvokeAsync( async ()  =>
            {
                 await GetTweets();
                StateHasChanged();
            });
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

    }
    
    private async Task GetTweets()
    {
        Loading = true;
        StateHasChanged();
        var json = await HttpClient.GetStringAsync($"{BaseUri}umbraco/backoffice/api/DashboardApi/GetUmbracoTweets");
        json = json.RemoveUmbracoAngularStartJson();
        var newTweets = JsonConvert.DeserializeObject<IEnumerable<TweetV2>>(json);
        Tweets = Tweets.Union(newTweets, new TweetComparer()).OrderByDescending(x => x.CreatedAt); 
        Loading = false;
    }
}