namespace BlazorExample.Shared.Models.Config;

public class BlazorExampleAppSettings
{
    public TwitterApiCredentials? TwitterApiCredentials { get; set; }
}

public class TwitterApiCredentials
{
    public string? ApiKey { get; set; }
    public string? ApiKeySecret { get; set; }
    public string? BearerToken { get; set; }
    public string? AccessToken { get; set; }
    public string? AccessTokenSecret { get; set; }
}