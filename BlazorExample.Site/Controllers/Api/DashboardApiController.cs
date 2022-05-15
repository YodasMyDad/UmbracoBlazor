using Umbraco.Cms.Web.BackOffice.Controllers;
using System.Threading.Tasks;
using BlazorExample.Shared.Models.Config;
using Microsoft.Extensions.Options;
using Tweetinvi;
using Tweetinvi.Models.V2;

namespace BlazorExample.Site.Controllers.Api;

public class DashboardApiController : UmbracoAuthorizedApiController
{
    
    private readonly BlazorExampleAppSettings _blazorExampleAppSettings;
    public DashboardApiController(IOptions<BlazorExampleAppSettings> options)
    {
        _blazorExampleAppSettings = options.Value;
    }
    
    public async Task<TweetV2[]> GetUmbracoTweets()
    {
        var userClient = new TwitterClient(_blazorExampleAppSettings.TwitterApiCredentials?.ApiKey, 
            _blazorExampleAppSettings.TwitterApiCredentials?.ApiKeySecret, 
            _blazorExampleAppSettings.TwitterApiCredentials?.AccessToken, 
            _blazorExampleAppSettings.TwitterApiCredentials?.AccessTokenSecret);
        var searchResponse = await userClient.SearchV2.SearchTweetsAsync("#umbraco");
        var tweets = searchResponse.Tweets;
        return tweets;
    }
}